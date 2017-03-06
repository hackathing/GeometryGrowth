using UnityEngine;

public class Selectable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetHighlight(bool shouldHighlight)
    {
        var components = GetComponentsInChildren<MeshRenderer>(includeInactive: true);

        foreach (var component in components)
        {
            if (component.gameObject.name == "Highlight")
            {
                var outlineRenderer = component.GetComponent<MeshRenderer>();
                outlineRenderer.enabled = shouldHighlight;
            }
        }
    }
}
