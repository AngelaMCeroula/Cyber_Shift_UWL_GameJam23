using System.Collections.Generic;
using UnityEngine;

namespace Checkpoints
{
    public class CheckPointManager : MonoBehaviour
    {
        private WorldStateSetter _worldStateSetter;
        public List<GameObject> checkpointsA; 
        public List<GameObject> checkpointsB;
        private int currentCheckpoint;
        
        private void Start()
        {
            _worldStateSetter = GameObject.Find("WorldStateManager").GetComponent<WorldStateSetter>();
        }

        public GameObject GetLastCheckpoint()
        {
            if (_worldStateSetter._isInWorldA)
            {
                return checkpointsA[currentCheckpoint];
            }
            else
            {
                return checkpointsB[currentCheckpoint];
            }
        }

        public void SaveCurrentCheckpoint(GameObject checkpoint)
        {
            if (_worldStateSetter._isInWorldA)
            {
                if (checkpointsA.Contains(checkpoint))
                    currentCheckpoint = checkpointsA.IndexOf(checkpoint);
            }
            else
            {
                if (checkpointsB.Contains(checkpoint))
                    currentCheckpoint = checkpointsB.IndexOf(checkpoint);
            }
        }
    }
}
