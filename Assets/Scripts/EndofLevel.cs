using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndofLevel : MonoBehaviour
{
    private Timer timer;

    private void Start()
    {
        timer = GameObject.Find("TimeManager").GetComponent<Timer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            timer.StopStopwatch();
            SceneManager.LoadScene("FinalScene");
        }
     
        
    }
}
