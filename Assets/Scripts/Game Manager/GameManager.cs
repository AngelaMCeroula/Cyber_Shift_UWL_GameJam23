using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private PlayerHealthEnergy _PlayerH_E;
    public GameObject GameOverScreen;
    public List<Transform> checkpointLocationA;
    public List<Transform> checkpointLocationB;
    public GameObject _gameObject;


    void Start()
    {
        _PlayerH_E = GameObject.Find("Player").GetComponent<PlayerHealthEnergy>();
        GameOverScreen.SetActive(false);
    }

    void Update()
    {
        
    }


    public void LoseLife()
    {
        if (_PlayerH_E.lives > 1)
        {
            _PlayerH_E.lives--;
            WraptoCheckPoint();
        }

        if (_PlayerH_E.lives <= 1)
        {
            GameOver();
        }

    }
    void WraptoCheckPoint()
    {

    }
    
    void GameOver()
    {
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
    }
}
