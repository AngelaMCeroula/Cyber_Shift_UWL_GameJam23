using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressShift : MonoBehaviour
{
    public GameObject pressShift;
    public float timeInSeconds = 5;

    private void Start()
    {
        pressShift.SetActive(false);
    }

    public void TeleportText()
    {
        StartCoroutine(TeleportTutorialTextDuration());
    }
    

    private IEnumerator TeleportTutorialTextDuration()
    {
        pressShift.SetActive(true);
        yield return new WaitForSeconds(timeInSeconds);
        pressShift.SetActive(false);
        
    }
}
