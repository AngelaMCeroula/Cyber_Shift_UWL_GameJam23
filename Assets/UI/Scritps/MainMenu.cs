using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float delayInSeconds = 1;
    public void PlayGame()
    {
        StartCoroutine(DelayPlayGame());
    }

    public void ExitGame()
    {
        StartCoroutine(DelayExitGame());
    }

    public void MainScene()
    {
        StartCoroutine(DelayMainScene());
    }

    IEnumerator DelayPlayGame()
    {
        
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("GameLevel");
    }
    IEnumerator DelayExitGame()
    {
        Debug.Log("Exit Game");
        yield return new WaitForSeconds(delayInSeconds);
        Application.Quit();
    }
    
    IEnumerator DelayMainScene()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("MainMenu");
        
    }

    public void PlaySoundIn()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Menu/MenuButtonIn", GetComponent<Transform>().position);
    }

    public void PlaySoundOut()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/Menu/MenuButtonOut", GetComponent<Transform>().position);
    }
}
