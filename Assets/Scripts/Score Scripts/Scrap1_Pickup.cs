using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap1_Pickup : MonoBehaviour
{ 

    public AudioClip scrap1sound;
    
    private void OnTriggerEnter2D(Collider2D col) // when object enters trigger box
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Scrap1");
            //UpdateUI
            AddPoint();
            PlaySound();
            Destroy(gameObject);
        }
            
    }

    void PlaySound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerFunction/PlayerSFX/ItemPickUp", GetComponent<Transform>().position);
    }

    void AddPoint()
    {
        ScoreManager.instance.AddPointScrap1();
    }
    
}

