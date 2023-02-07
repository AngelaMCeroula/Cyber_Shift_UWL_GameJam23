using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    public Vector3 offset2;
    [Range(1,10)]public float smoothFactor;
    public Vector3 minValues, maxValues;

    // Update is called once per frame
    void Update()
    {
        //CameraFollow();
    }

    private void FixedUpdate()
    {
        //CameraFollow2();
        //CameraFollow3();
        CameraFollow4();
    }

    void CameraFollow()
    {
        // Camera follows the player with specified offset position
        //transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
        transform.position = new Vector3(player.position.x + offset.x,offset.y, offset.z);
        
    }
    
    void CameraFollow2()
    {
        //camera follow player with smooth and offset
        
        Vector3 playerPosition = player.position + offset2;
       
        Vector3 smoothPosition = Vector3.Lerp(transform.position, playerPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
        
    }

    void CameraFollow3()
    {
        
        //camera follow player with smooth and offset
        // define minimum and max x,y,z values
       
        Vector3 playerPosition = player.position + offset2;
        //Verify if the PlayerPosition is out of bounds or not
        //Limit it to the min and max values
        
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(playerPosition.x,minValues.x, maxValues.x),
            Mathf.Clamp(playerPosition.y,minValues.y,maxValues.y), 
            Mathf.Clamp(playerPosition.z,minValues.z,maxValues.z));
        
        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;

    }

    void CameraFollow4()
    {
        Vector3 playerPosition = player.position + offset2;
        
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(playerPosition.x,minValues.x, maxValues.x),
            Mathf.Clamp(playerPosition.y,minValues.y,maxValues.y), 
            Mathf.Clamp(playerPosition.z,minValues.z,maxValues.z));

        transform.position = boundPosition;

    }
    
}
