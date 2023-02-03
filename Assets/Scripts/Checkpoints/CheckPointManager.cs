using System.Collections.Generic;
using UnityEngine;

namespace Checkpoints
{
    public class CheckPointManager : MonoBehaviour
    {
        public List<Transform> checkpointLocationA;
        public List<Transform> checkpointLocationB;
        private WorldStateSetter _worldStateSetter;
       // private 


        private void Start()
        {
            _worldStateSetter = GameObject.Find("WorldStateManager").GetComponent<WorldStateSetter>();
        }

        public void SavePointInA()
        {
            
           
        }

        public void SavePointInB()
        {
           
        }
        
        


        void WraptoCheckPoint()
        {
            switch (_worldStateSetter._isInWorldA)
            {
                case true:
                {
                
                    break;
                }

                case false:
                {
                
                    break;
                }        

            }

        }

    
    }
}
