using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndofLevel : MonoBehaviour
{
    private Timer timer;
    public float delayInSeconds = 0;

    private void Start()
    {
        timer = GameObject.Find("TimeManager").GetComponent<Timer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            timer.StopStopwatch();
            FMODUnity.RuntimeManager.PlayOneShot("event:/InGame/Level/LevelEnd", GetComponent<Transform>().position);
            SceneManager.LoadScene("FinalScene");
            //StartCoroutine(EndSceneDelay());
        }

    }

    IEnumerator EndSceneDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("FinalScene");
        
    }
}
