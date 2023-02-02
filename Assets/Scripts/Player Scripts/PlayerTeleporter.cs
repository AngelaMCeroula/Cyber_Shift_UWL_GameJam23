using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    private bool _recentTeleport;
    public float delayInSeconds = 1;
    private bool _teleportedToB;
    //public Vector3 teleportDistance;

    private void Start()
    {
        _recentTeleport = false;
        _teleportedToB = false;
    }

    private void Update()
    {
        ProcessInputs();
    }

    private void ProcessInputs()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _recentTeleport == false && _teleportedToB == false)
        {
            TeleportUp();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && _recentTeleport == false && _teleportedToB == true)
        {
            TeleportDown();
           
        }
        
        
        
    }

    private void TeleportUp()
    {
        //teleport 20 up in relation to self
        Vector3 up = new Vector3(200,0,0);
       
        gameObject.transform.position += up;
        _recentTeleport = true;
        _teleportedToB = true;
        StartCoroutine(TeleportDelay());
    }
    
    private void TeleportDown()
    {
        //teleport 20 down in relation to self
        Vector3 down = new Vector3(-200,0,0);
       
        gameObject.transform.position += down;
        _recentTeleport = true;
        _teleportedToB = false;
        StartCoroutine(TeleportDelay());
    }
    
    
    

    private IEnumerator TeleportDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        _recentTeleport = false;
    }

}
