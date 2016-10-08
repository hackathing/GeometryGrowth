using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class WandController : MonoBehaviour
    {
        public GameObject PrefabToSpawn;

        private SteamVR_Controller.Device Controller { get { return SteamVR_Controller.Input((int)_trackedObj.index); } }
        private SteamVR_TrackedObject _trackedObj;

        // Use this for initialization
        void Start()
        {
            _trackedObj = GetComponent<SteamVR_TrackedObject>();
        }

        // Update is called once per frame
        void Update()
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

        void GrowTree(Vector3 position)
        {
            Instantiate(PrefabToSpawn, position, Quaternion.identity);
        }

        void OnTriggerEnter(Collider col)
        {
            var seed = col.gameObject.GetComponent<Seed>();
            seed.SetHighlight(true);
        }

        void OnTriggerExit(Collider col)
        {
            var seed = col.gameObject.GetComponent<Seed>();
            seed.SetHighlight(false);
        }
    }
}


