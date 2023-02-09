using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed; // speed of platform
    public int startingPoint; //starting index
    public Transform[] points; // array of transforms

    private int i; // index of array

    private void Start()
    {
        // setting position of the platform t the pos of stating point in index
        transform.position = points[startingPoint].position;
    }

    private void Update()
    {
        // checks distance of platform and point
        if (Vector2.Distance(transform.position, points[i].position) < 0.2f)
        {
            i++; // increase index
            if (i == points.Length) // check if the plat was on the last point after increase
            {
                i = 0; //reset index

            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.SetParent(null);
    }
}
