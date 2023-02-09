using System;
using System.Collections;
using System.Collections.Generic;
using Checkpoints;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthEnergy : MonoBehaviour
{
    [Range(0,5)]public int lives;
    [Range(0,5)]public int battery;
    private int _batteryMaxCapacity = 5;
    public GameManager GameManager;
    public int timePerCharge = 20;
    public int respawnDelay;
    private bool charging = false;
    private CheckPointManager CP_manager;


    private void Start()
    {
        CP_manager = GameObject.Find("GameManager").GetComponent<CheckPointManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Danger") || col.gameObject.CompareTag("Enemy"))
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

        switch (lives)
        {
            case 5:
            {
                lives--;
                StartCoroutine(RespawnDelay());
                FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerFunction/PlayerSFX/PlayerDamage", GetComponent<Transform>().position);
                break;
            }
            case 4:
            {
                lives--;
                StartCoroutine(RespawnDelay());
                FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerFunction/PlayerSFX/PlayerDamage", GetComponent<Transform>().position);
                break;
            }
            case 3:
            {
                lives--;
                StartCoroutine(RespawnDelay());
                FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerFunction/PlayerSFX/PlayerDamage", GetComponent<Transform>().position);
                break;
            }
            case 2:
            {
                lives--;
                StartCoroutine(RespawnDelay());
                FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerFunction/PlayerSFX/PlayerDamage", GetComponent<Transform>().position);
                break;
            }
            case 1:
            {
                lives--;
                FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerFunction/PlayerSFX/PlayerDeath", GetComponent<Transform>().position);
                SceneManager.LoadScene("GameOver");
                break;
            }
            
        }
        
        
     /*
    
        if (lives >= 1)
        {
            lives--;
            StartCoroutine(RespawnDelay());
            
        }

        if (lives < 1)
        {
            GameManager.GameOver();
        }
        
        */
    }

    private void Update()
    {
        //UseBat();
    }


    public void TestBat()
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

    public void UseBat()
    {
        battery--;
        if (battery < _batteryMaxCapacity && charging == false)
        {
            StartCoroutine(Recharge());
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

    IEnumerator RespawnDelay()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(respawnDelay);
        gameObject.transform.position = CP_manager.GetLastCheckpoint().transform.position;
        Time.timeScale = 1;
    }

}
