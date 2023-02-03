using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthEnergy : MonoBehaviour
{
    [Range(0,5)]public int lives;
    [Range(0,5)]public int battery;
    private int _batteryMaxCapacity = 5;
    public GameManager GameManager;
    public int timePerCharge = 20;
    private bool charging = false;



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
        UseBat();
    }

   

    void UseBat()
    {
        if (Input.GetKeyDown(KeyCode.E) && battery > 0)
        {
            battery--;
            if (battery < _batteryMaxCapacity && charging == false)
            {
                StartCoroutine(Recharge());
            }
        }
    }

    IEnumerator Recharge()
    {
        charging = true;
        yield return new WaitForSeconds(timePerCharge);
        battery++;
        charging = false;
        
        if (battery < _batteryMaxCapacity)
        {
            StartCoroutine(Recharge());
        }
    }

}
