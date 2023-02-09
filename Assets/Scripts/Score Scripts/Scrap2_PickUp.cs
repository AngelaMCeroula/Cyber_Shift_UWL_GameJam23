using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap2_PickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col) // when object enters trigger box
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Scrap2");
            //UpdateUI
            AddPoint2();
            PlaySound();
            Destroy(gameObject);
            
        }
            
    }
    
    void PlaySound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerFunction/PlayerSFX/ItemPickUp", GetComponent<Transform>().position);
    }

    void AddPoint2()
    {
        ScoreManager.instance.AddPointScrap2();
    }
}

