using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerHealthEnergy _PlayerH_E;
    public GameObject GameOverScreen;

    void Start()
    {
        _PlayerH_E = GameObject.Find("Player").GetComponent<PlayerHealthEnergy>();
        GameOverScreen = GameObject.Find("GameOverScreen");
        GameOverScreen.SetActive(false);
    }

    void Update()
    {
        if (_PlayerH_E.lives < 1)
        {
            GameOver();

        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
        
    }
}
