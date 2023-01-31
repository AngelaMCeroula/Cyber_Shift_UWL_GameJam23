using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap2_PickUp : MonoBehaviour
{ 

    public AudioClip scrap2sound;
    
    private void OnTriggerEnter2D(Collider2D col) // when object enters trigger box
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Scrap2");
            //UpdateUI
            AddPoint2();
            //PlaySound();
            Destroy(gameObject);
            
        }
            
    }
    
    void PlaySound()
    {
        AudioSource.PlayClipAtPoint(scrap2sound, transform.position);
    }

    void AddPoint2()
    {
        ScoreManager.instance.AddPointScrap2();
    }
}

