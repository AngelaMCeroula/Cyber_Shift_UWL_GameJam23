using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    private bool _recentTeleport;
    public float delayInSeconds = 1;
    //public Vector3 teleportDistance;

    private void Start()
    {
        _recentTeleport = false;
    }

    private void Update()
    {
        ProcessInputs();
    }

    private void ProcessInputs()
    {
        if (Input.GetKeyDown(KeyCode.Q) && _recentTeleport == false)
        {
            Teleport();
        }
        
        
        
    }

    private void Teleport()
    {
        //teleport 20 up in relation to self
        Vector3 up = new Vector3(0,20,0);
       
        gameObject.transform.position += up;
        _recentTeleport = true;
        StartCoroutine(TeleportDelay());
    }

    private IEnumerator TeleportDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        _recentTeleport = false;
    }

}
