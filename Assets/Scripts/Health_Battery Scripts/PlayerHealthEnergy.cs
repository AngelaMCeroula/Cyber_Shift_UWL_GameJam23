using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthEnergy : MonoBehaviour
{
    [Range(0,5)]public int lives;
    [Range(0,5)]public int battery;
    
    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Danger"))
        {
            lives--;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Danger"))
        {
            lives--;
        }
    }
}
