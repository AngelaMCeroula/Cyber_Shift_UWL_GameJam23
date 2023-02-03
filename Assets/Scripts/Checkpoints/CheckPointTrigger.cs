using System;
using UnityEngine;

namespace Checkpoints
{
    public class CheckPointTrigger : MonoBehaviour
    {
        private GameManager _gameManager;
        private GameMaster _gm;
        private PlayerTeleporter _teleporter;

        void Start()
        {
            _gm = GameObject.Find("GameMaster").GetComponent<GameMaster>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                // transform.position = new Vector3(gameObject.position.x + offset.x,offset.y, offset.z);
                
            
                
            }
        }
    }
}
