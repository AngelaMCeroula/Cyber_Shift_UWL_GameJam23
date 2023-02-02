using UnityEngine;

namespace Checkpoints
{
    public class CheckPointTrigger : MonoBehaviour
    {
        private GameManager _gameManager;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                // transform.position = new Vector3(gameObject.position.x + offset.x,offset.y, offset.z);
            
                
            }
        }
    }
}
