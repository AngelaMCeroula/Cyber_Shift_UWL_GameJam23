using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    public static int score = 0;
    public static int highscore = 0;
    

    private void Awake()
    {
        instance = this;
        score = 0;
    }


    // Start is called before the first frame update
    void Start()
    { 
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString();
        highscoreText.text = highscore.ToString();

        if (instance == null)
        {
            instance = this;
        }

    }

    public void AddPointScrap1()
    {
        //adds points to the score text, must be referenced on trash items script "ScoreManager.instance.AddPoint();"
        score += 1;
        scoreText.text = score.ToString();
        HScore();
    }
    
    public void AddPointScrap2()
    {
        //adds points to the score text, must be referenced on trash items script "ScoreManager.instance.AddPoint();"
        score += 2;
        scoreText.text = score.ToString();
        HScore();
        
    }
    
    public void AddPointScrap3()
    {
        //adds points to the score text, must be referenced on trash items script "ScoreManager.instance.AddPoint();"
        score += 5;
        scoreText.text = score.ToString();
        HScore();
        
    }
    
    
   
   
    public void HScore()
    { if (highscore < score)
        { 
            PlayerPrefs.SetInt("highscore", score);
        }
        
    }
    
    
/*
    
    public void PointMultiplier()
    {
        score *= 2;
        scoreText.text = score.ToString();
        // add text and a delay
        Invoke(nameof(ScenePlayDelay), 1);
        HScore();
        
    }

    public void ScenePlayDelay()
    {
        SceneManager.LoadScene("FinalMenu");
    }

*/

}
