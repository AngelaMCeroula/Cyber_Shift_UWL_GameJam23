using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthEnergy : MonoBehaviour
{
    [Range(0,5)]public int lives;
    [Range(0,5)]public int battery;
    public GameManager GameManager;



    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Danger"))
        {
            LoseLife();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Danger"))
        {
            LoseLife();
        }
    }

    void LoseLife()
    {
        if (lives >= 1)
        {
            lives--;
            
        }

        if (lives < 1)
        {
            GameManager.GameOver();
        }

        
    }

    private void Update()
    {
        
    }

    void Recharge()
    {
        
    }
}
