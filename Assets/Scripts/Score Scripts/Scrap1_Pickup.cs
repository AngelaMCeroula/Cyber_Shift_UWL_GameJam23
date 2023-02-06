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
            
            AddPoint();
            //PlaySound();
            Destroy(gameObject);
        }
            
    }

    void PlaySound()
    {
        AudioSource.PlayClipAtPoint(scrap1sound, transform.position);
    }

    void AddPoint()
    {
        ScoreManager.instance.AddPointScrap1();
    }
    
}

