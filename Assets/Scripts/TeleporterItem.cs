using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterItem : MonoBehaviour
{
    private PlayerTeleporter _playerTeleporter;
    private Timer _timer;

    // Start is called before the first frame update
    void Start()
    {
        _playerTeleporter = GameObject.Find("Player").GetComponent<PlayerTeleporter>();
        _timer = GameObject.Find("TimeManager").GetComponent<Timer>();

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _playerTeleporter._hasTeleporter = true;
            _timer.StartStopWatch();
            Destroy(gameObject);
            
        }
    }
}