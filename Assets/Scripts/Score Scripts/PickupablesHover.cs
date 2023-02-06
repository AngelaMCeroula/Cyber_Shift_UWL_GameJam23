using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupablesHover : MonoBehaviour
{
    private Vector3 startPos;
    public float frequency = 3f;
    public float magnitude = 0.2f;
    public float offset = 0;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.position = startPos + transform.up * (Mathf.Sin(Time.time * frequency + offset) * magnitude);
    }
}
