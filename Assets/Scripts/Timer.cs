using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private bool stopwatchActive = false;
    public static float _currentTime;
    public TMP_Text _currentTimeText;
    

    private void Start()
    {
        _currentTime = 0;
        //StartStopWatch();
    }

    private void Update()
    {
        if (stopwatchActive == true)
        {
            _currentTime = _currentTime + Time.deltaTime;
        }

        TimeSpan time = TimeSpan.FromSeconds(_currentTime);
        _currentTimeText.text = time.ToString(@"mm\:ss");
    }

    public void StartStopWatch()
    {
        stopwatchActive = true;
    }

    public void StopStopwatch()
    {
        stopwatchActive = false;
    }
    
}
