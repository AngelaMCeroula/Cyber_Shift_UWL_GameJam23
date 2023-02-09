using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExteriorTrigger : MonoBehaviour
{
   public GameObject exteriorTileMap;

   void OnTriggerStay2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         exteriorTileMap.SetActive(false);
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         exteriorTileMap.SetActive(true);
      }
   }
}
