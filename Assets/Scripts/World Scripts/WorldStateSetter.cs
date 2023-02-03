using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateSetter : MonoBehaviour
{
    public bool _isInWorldA;
    public GameObject WorldAIndicator;
    public GameObject WorldBIndicator;

    private void Update()
    {
        switch (_isInWorldA)
        {
            case false:
            {
                WorldBIndicator.SetActive(true);
                WorldAIndicator.SetActive(false);
                break;
            }

            case true:
            {
                WorldBIndicator.SetActive(false);
                WorldAIndicator.SetActive(true);
                break;
                
            }

        }       
    }
}
