using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_BatteryManager : MonoBehaviour
{
    private PlayerHealthEnergy _PlayerH_E;
    public GameObject lives0, lives1, lives2, lives3, lives4, lives5;
    public GameObject battery0, battery1, battery2, battery3, battery4, battery5;
    

    void Start()
    {
       _PlayerH_E = GameObject.Find("Player").GetComponent<PlayerHealthEnergy>();
      
       lives0.gameObject.SetActive(false);
       lives1.gameObject.SetActive(false);
       lives2.gameObject.SetActive(false);
       lives3.gameObject.SetActive(false);
       lives4.gameObject.SetActive(false);
       lives5.gameObject.SetActive(true);
       
    }

    private void Update()
    {
        UpdateLives();
        UpdateBattery();
    }


    void UpdateBattery()
    {
        switch (_PlayerH_E.battery)
        {
            case 5:
            {
                battery5.gameObject.SetActive(true);
                battery4.gameObject.SetActive(false);
                battery3.gameObject.SetActive(false);
                battery2.gameObject.SetActive(false);
                battery1.gameObject.SetActive(false);
                battery0.gameObject.SetActive(false);
                break;
            }
            case 4:
            {
                battery5.gameObject.SetActive(false);
                battery4.gameObject.SetActive(true);
                battery3.gameObject.SetActive(false);
                battery2.gameObject.SetActive(false);
                battery1.gameObject.SetActive(false);
                battery0.gameObject.SetActive(false);
                break;
            }
            case 3:
            {
                battery5.gameObject.SetActive(false);
                battery4.gameObject.SetActive(false);
                battery3.gameObject.SetActive(true);
                battery2.gameObject.SetActive(false);
                battery1.gameObject.SetActive(false);
                battery0.gameObject.SetActive(false);
                break;
            }
            case 2:
            {
                battery5.gameObject.SetActive(false);
                battery4.gameObject.SetActive(false);
                battery3.gameObject.SetActive(false);
                battery2.gameObject.SetActive(true);
                battery1.gameObject.SetActive(false);
                battery0.gameObject.SetActive(false);
                break;
            }
            case 1:
            {
                battery5.gameObject.SetActive(false);
                battery4.gameObject.SetActive(false);
                battery3.gameObject.SetActive(false);
                battery2.gameObject.SetActive(false);
                battery1.gameObject.SetActive(true);
                battery0.gameObject.SetActive(false);
                break;
            }
            case 0:
            {
                battery5.gameObject.SetActive(false);
                battery4.gameObject.SetActive(false);
                battery3.gameObject.SetActive(false);
                battery2.gameObject.SetActive(false);
                battery1.gameObject.SetActive(false);
                battery0.gameObject.SetActive(true);
                break;
            }
            
        }
            
    }
    
    void UpdateLives()
    {

        switch (_PlayerH_E.lives)
        {
            case 5:
            {
                lives5.gameObject.SetActive(true);
                break;
            }
            case 4:
            {
                lives4.gameObject.SetActive(true);
                lives5.gameObject.SetActive(false);
                break;
            }
            case 3:
            {
                lives3.gameObject.SetActive(true);
                lives4.gameObject.SetActive(false);
                break;
            }
            case 2:
            {
                lives2.gameObject.SetActive(true);
                lives3.gameObject.SetActive(false);
                break;
            }
            case 1:
            {
                lives1.gameObject.SetActive(true);
                lives2.gameObject.SetActive(false);
                break;
            }
            case 0:
            {
                lives0.gameObject.SetActive(true);
                lives1.gameObject.SetActive(false);
                break;
            }
            
        }
            
    }
}
