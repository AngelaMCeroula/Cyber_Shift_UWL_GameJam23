using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterItem : MonoBehaviour
{
    private PlayerTeleporter _playerTeleporter;
    private Timer _timer;
    private PressShift _pressShift;

    // Start is called before the first frame update
    void Start()
    {
        _playerTeleporter = GameObject.Find("Player").GetComponent<PlayerTeleporter>();
        _timer = GameObject.Find("TimeManager").GetComponent<Timer>();
        _pressShift = GameObject.Find("GameManager").GetComponent<PressShift>();

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _playerTeleporter._hasTeleporter = true;
            _timer.StartStopWatch();
            _pressShift.TeleportText();
            FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerFunction/PlayerSFX/ItemPickUp", GetComponent<Transform>().position);
            Destroy(gameObject);
            
        }
    }
}