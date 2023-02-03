using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldACheck : MonoBehaviour
{
    public WorldStateSetter _wState;

    private void Start()
    {
        _wState = GameObject.Find("WorldStateManager").GetComponent<WorldStateSetter>();

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _wState._isInWorldA = true;
        }
        else
        {
            _wState._isInWorldA = false;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _wState._isInWorldA = false;

        }
    }
}
