using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrapt3_PickUp : MonoBehaviour
{ 

    public AudioClip scrap3sound;
    
    private void OnTriggerEnter2D(Collider2D col) // when object enters trigger box
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Scrap3");
            AddPoint3();
            PlaySound();
            Destroy(gameObject);
        }
            
    }
    
    
    void PlaySound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerFunction/PlayerSFX/ItemPickUp", GetComponent<Transform>().position);
    }

    void AddPoint3()
    {
        ScoreManager.instance.AddPointScrap3();
    }

}
