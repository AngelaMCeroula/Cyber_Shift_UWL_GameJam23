using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterMainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    private GameObject StartCanvas;

    private void Start()
    {
        StartCanvas = GameObject.Find("StartCanvas");
    }

    private void Update()
    {
        ProcessInputs();
    }

    void ProcessInputs()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            MainMenu.SetActive(true);
            StartCanvas.SetActive(false);
        }
    }

}