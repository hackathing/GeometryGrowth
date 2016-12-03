using UnityEngine;
using System.Collections;

public class OlegTree : MonoBehaviour {

  public Mesh mesh;
  public Material material;
  public int maxDepth;
  public float childScale;
  public float growthFrameTime;
  public float spawnProbability;
  public float growthDuration;  // The growthDuration variable is not working as intended here

  private int depth;

  private static Vector3[] childDirections = {
    Vector3.up,
    Vector3.right,
    Vector3.left
  };

  private static Quaternion[] childOrientations = {
    Quaternion.identity,
    Quaternion.Euler(0f, 0f, -60f),
    Quaternion.Euler(0f, 0f, 60f)
  };

  // This is a bit weird. This is to compensate for the parent scale
  private static Vector3[] childScales = {
    new Vector3(1f, 1f, 1f),
    new Vector3(0.5f, 2f, 1f),
    new Vector3(0.5f, 2f, 1f)
  };

  // Use this for initialization
  void Start () {
    var meshFilter = gameObject.AddComponent<MeshFilter>();
      meshFilter.mesh = mesh;
      var meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = material;
    if (depth < maxDepth) {
      StartCoroutine(CreateChildren());
    }

    // Debug.Log("growthDuration in Start");
    // Debug.Log(this);
    // Debug.Log(growthDuration);

  }

  private IEnumerator CreateChildren () {
    for (int i = 0; i < childDirections.Length; i++) {
      if (Random.value < spawnProbability) {
        yield return new WaitForSeconds (growthFrameTime);

        new GameObject ("OlegTree Child").AddComponent<OlegTree> ().Initialize (this, growthDuration, i);
      }
    }
  }

  private void Initialize (OlegTree parent, float growthDuration, int childIndex) {
    spawnProbability = parent.spawnProbability;
    mesh = parent.mesh;
    material = parent.material;
    maxDepth = parent.maxDepth;
    growthFrameTime = parent.growthFrameTime;
    depth = parent.depth + 1;
    childScale = parent.childScale;
    transform.parent = parent.transform;
    transform.localPosition = childDirections[childIndex] * 0.5f;
    transform.localRotation = childOrientations[childIndex];
    // Debug.Log("growthDuration in Initialize");
    // Debug.Log(growthDuration);
    StartCoroutine(scaleObject(childIndex, growthDuration));
  }

  private IEnumerator scaleObject(int childIndex, float growthDuration) {

    Vector3 initialScale = Vector3.one * 0;
    // Vector3 initialPosition = this.transform.localPosition;
    
    this.transform.localScale = initialScale;
    Vector3 destinationScale = (childScales[childIndex] * childScale);
    Vector3 destinationPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);

    // Debug.Log(this.transform.localScale);
    // Debug.Log(this.transform.localPosition);

    float time = 10.0f;
    float currentTime = 0.0f;
    
    do
    {
      // this.transform.localScale = Vector3.Lerp(this.transform.localScale, destinationScale, currentTime / time);
      // Debug.Log("growthDuration in scaleObject,");
      // Debug.Log(childIndex);
      // Debug.Log(growthDuration);
      // this.transform.localScale = Growth.NewPosition(this.transform.localScale, initialScale, destinationScale, growthDuration);
      // this.transform.localPosition = Growth.NewPosition(this.transform.localPosition, initialPosition, destinationPosition, growthDuration);

      // The growthDuration variable is not working as intended here
      this.transform.localScale = Vector3.Lerp(this.transform.localScale, destinationScale, currentTime / time);
      this.transform.localPosition = Vector3.Lerp(this.transform.localPosition, destinationPosition, currentTime / time);
      
      currentTime += Time.deltaTime;
      yield return null;
    } while (currentTime <= time);
  }

  // Update is called once per frame
  void Update () {

  }
}
