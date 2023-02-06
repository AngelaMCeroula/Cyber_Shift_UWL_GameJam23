using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateSetter : MonoBehaviour
{
    public bool _isInWorldA;
    public GameObject WorldAIndicator;
    public GameObject WorldBIndicator;

    public GameObject WorldABG;
    public GameObject WorldBBG;

    private void Update()
    {
        if (_isInWorldA == true)
        {
            WorldABG.SetActive(true);
            WorldBBG.SetActive(false);
            WorldBIndicator.SetActive(false);
            WorldAIndicator.SetActive(true);
        }

        else
        {
            WorldBBG.SetActive(true);
            WorldABG.SetActive(false);
            WorldBIndicator.SetActive(true);
            WorldAIndicator.SetActive(false);
            
        }
      
        /* 
        switch (_isInWorldA)
        {
            case false:
            {
                WorldBBG.SetActive(true);
                WorldABG.SetActive(false);
                WorldBIndicator.SetActive(true);
                WorldAIndicator.SetActive(false);
                break;
            }

            case true:
            {
                WorldABG.SetActive(true);
                WorldBBG.SetActive(false);
                WorldBIndicator.SetActive(false);
                WorldAIndicator.SetActive(true);
                break;
                
            }
            

        }    
        */   
    }
}
