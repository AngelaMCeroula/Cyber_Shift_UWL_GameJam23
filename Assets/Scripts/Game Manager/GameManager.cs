using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    //private PlayerHealthEnergy _PlayerH_E;
    public GameObject GameOverScreen;
    public Timer _Timer;




    void Start()
    {
        GameOverScreen.SetActive(false);
        _Timer = GameObject.Find("TimeManager").GetComponent<Timer>();
    }
    
    public void GameOver()
    {
        Time.timeScale = 0;
        _Timer.StopStopwatch();
        GameOverScreen.SetActive(true);
    }
}
