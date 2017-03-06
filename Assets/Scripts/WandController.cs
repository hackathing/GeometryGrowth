using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class WandController : MonoBehaviour
    {
        public GameObject PrefabToSpawn;

        private SteamVR_Controller.Device Controller
        {
            get { return SteamVR_Controller.Input((int) _trackedObj.index); }
        }

        private SteamVR_TrackedObject _trackedObj;

        public GameObject SelectedObject { get; private set; }
        public GameObject GrabbedObject { get; private set; }

        // Use this for initialization
        private void Start()
        {
            _trackedObj = GetComponent<SteamVR_TrackedObject>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (Controller == null)
            {
                return;
            }

            var gripButtonPress = Controller.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger);

            if (gripButtonPress)
            {
                GrowTree(Controller.transform.pos);
            }
        }

        private void GrowTree(Vector3 position)
        {
            Instantiate(PrefabToSpawn, position, Quaternion.identity);
        }

        private void OnTriggerEnter(Collider col)
        {
            SelectObject(col.gameObject);
        }

        private void OnTriggerExit(Collider col)
        {
            UnselectObject(col.gameObject);
        }

        private void SelectObject(GameObject obj)
        {
            if (SelectedObject == null && GrabbedObject == null)
            {
                var selectable = gameObject.GetComponent<Selectable>();
                if (selectable != null)
                {
                    selectable.SetHighlight(true);
                    SelectedObject = obj;
                }
            }
        }

        private void UnselectObject(GameObject obj)
        {
            if (SelectedObject == obj)
            {
                var selectable = gameObject.GetComponent<Selectable>();

                if (selectable != null)
                {
                    selectable.SetHighlight(false);
                    SelectedObject = null;
                }
            }

        }
    }
}



