using System;
using UnityEngine;

namespace Checkpoints
{
    public class CheckPointTrigger : MonoBehaviour
    {
        private WorldStateSetter _worldStateSetter;
        private CheckPointManager _checkPointManager;

        void Start()
        {
            _worldStateSetter = GameObject.Find("WorldStateManager").GetComponent<WorldStateSetter>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {

            }
        }
    }
}
