using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour
{
    public bool _hasTeleporter;
    private bool _recentTeleport;
    public float delayInSeconds = 2;
    public Vector3 teleportOffset1;
    public Vector3 teleportOffset2;
    
    //private bool _teleportedToB;
    private WorldStateSetter _worldStateSetter;

    public GameObject transitionImg;
    public float transitionTime;

    private void Start()
    {
        _worldStateSetter = GameObject.Find("WorldStateManager").GetComponent<WorldStateSetter>();
        _recentTeleport = false;
        //_teleportedToB = false;
        _hasTeleporter = false;
        transitionImg.SetActive(false);
    }

    private void Update()
    {
        ProcessInputs();
    }

    private void ProcessInputs()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && _recentTeleport == false && _worldStateSetter._isInWorldA == true && _hasTeleporter == true)
        {
            TeleportUp();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && _recentTeleport == false && _worldStateSetter._isInWorldA == false && _hasTeleporter == true)
        {
            TeleportDown();
           
        }
        
        
        
    }

    private void TeleportUp()
    {
        //teleport 20 up in relation to self
        Vector3 up = new Vector3(300,0,0);
       
        gameObject.transform.position += teleportOffset1;
        _recentTeleport = true;
        _worldStateSetter._isInWorldA = true;
        StartCoroutine(TeleportDelay());
        //StartCoroutine(Transition());
    }
    
    private void TeleportDown()
    {
        //teleport 20 down in relation to self
        Vector3 down = new Vector3(-300,0,0);
       
        gameObject.transform.position += teleportOffset2;
        _recentTeleport = true;
        _worldStateSetter._isInWorldA = false;
        StartCoroutine(TeleportDelay());
        //StartCoroutine(Transition());
    }
    
    private IEnumerator TeleportDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        _recentTeleport = false;
    }

    private IEnumerator Transition()
    {
        transitionImg.SetActive(true);
        yield return new WaitForSeconds(transitionTime);
        transitionImg.SetActive(false);
    }

 

}
