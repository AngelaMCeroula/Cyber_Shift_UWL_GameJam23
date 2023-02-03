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
    public List<Transform> checkpointLocationA;
    public List<Transform> checkpointLocationB;
    public GameObject WorldStateManager;
    


    void Start()
    {
        //_PlayerH_E = GameObject.Find("Player").GetComponent<PlayerHealthEnergy>();
        GameOverScreen.SetActive(false);
        _Timer = GameObject.Find("TimeManager").GetComponent<Timer>();
    }
    
    void WraptoCheckPoint()
    {

    }
    
    public void GameOver()
    {
        Time.timeScale = 0;
        _Timer.StopStopwatch();
        GameOverScreen.SetActive(true);
    }
}
