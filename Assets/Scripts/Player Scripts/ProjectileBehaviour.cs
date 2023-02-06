using System;
using UnityEngine;

namespace Player_Scripts
{
    public class ProjectileBehaviour : MonoBehaviour
    {

        public float speed = 20;
        public float range = 1;
        // Start is called before the first frame update
        void Start()
        {
            WaitAndDestroy();

        }

        // Update is called once per frame
        void Update()
        {
            transform.position += -transform.right * (Time.deltaTime * speed);
        }


        void OnCollisionEnter2D(Collision2D col)
        {

            if (col.collider.CompareTag("Enemy"))
            {
               
                col.collider.GetComponent<EnemyAI>().Crush();
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        

        void WaitAndDestroy()
        {
            Destroy(this.gameObject, range);
        }
    }
}
