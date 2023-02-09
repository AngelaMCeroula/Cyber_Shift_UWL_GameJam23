using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    //When I was writing this I didn't know what I was doing, chances are I still won't know when I look at it, send help or Code Monkey on YT to teach me
    
    public Transform entryContainer;
    public Transform entryTemplate;
    public float templateHeight = 40;
    private int endScore;
    private float endTime;
    public GameObject InputFieldGameObject;
    private string pName;

    public GameObject lBoardCanvas;
    public GameObject userNameCanvas;

    //private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTranformList;


    public void StoreName()
    {
        //GetPlayer Input then trigger addHighscoreEntry

        pName = InputFieldGameObject.GetComponent<TextMeshProUGUI>().text;
        userNameCanvas.SetActive(false);
        lBoardCanvas.SetActive(true);
        AddHighscoreEntry(endScore, pName, endTime);
        LoadTable();
        

    }
    
    private void Start()
    {
        //GetPlayer Input then trigegr addHighscoreEntry
       

        //AddHighscoreEntry(endScore, pName, endTime);
        //AddHighscoreEntry(int score, string name, float time)
        //LoadTable();
    }

    
    
    private void Awake()
    {
        //entryContainer = transform.Find("highscoreEntryContainer");
        //entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);
        endScore = ScoreManager.score;
        endTime = Timer._currentTime;
    }

    private void LoadTable()
    {
        
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        
        // sort entry list by score

        if (highscores.highscoreEntryList.Count > 10) // added in
        {
            for (int h = highscores.highscoreEntryList.Count; h > 10; h--)
            {
                highscores.highscoreEntryList.RemoveAt(10);
            }
        }

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    // swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        

        highscoreEntryTranformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighScoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTranformList);
        }
        
    }

    private void CreateHighScoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List <Transform> transformList)
    {
        
        
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

       
        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "th"; break;
            case 1:
                rankString = "1st"; break;
            case 2:
                rankString = "2nd"; break;
            case 3:
                rankString = "3rd"; break;
        }

        
        entryTransform.Find("Pos_text").GetComponent<TextMeshProUGUI>().text = rankString;
        
        string name = highscoreEntry.name;
        entryTransform.Find("Score_text").GetComponent<TextMeshProUGUI>().text = name;

        int score = highscoreEntry.score;
        entryTransform.Find("Name_text").GetComponent<TextMeshProUGUI>().text = score.ToString();
        
        //TimeSpan time = TimeSpan.FromSeconds(endTime);
        TimeSpan time = TimeSpan.FromSeconds(highscoreEntry.time);
        
        entryTransform.Find("Time_text").GetComponent<TextMeshProUGUI>().text = time.ToString(@"mm\:ss");
        
        //set background visible for odds and evens, easier to read
        entryTransform.Find("entryBackground").gameObject.SetActive(rank % 2 == 1);


        // set badge
        switch (rank)
        {
            default:
                entryTransform.Find("badge").gameObject.SetActive(false);
                break;
            case 1:
                entryTransform.Find("badge").GetComponent<Image>().color = Color.yellow;
                break;
            case 2:
                entryTransform.Find("badge").GetComponent<Image>().color = Color.grey;
                break;
            case 3:
                entryTransform.Find("badge").GetComponent<Image>().color = Color.red;
                break;
        }
       
        transformList.Add(entryTransform);
        
    }

    private void AddHighscoreEntry(int score, string name, float time)
    { 
        //create highscore entry
        HighscoreEntry highscoreEntry = new HighscoreEntry{score = score, name = name, time = time};
        
        
        //load saved highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        
        if(highscores == null)
        {
            highscores = new Highscores();
        }
        if(highscores.highscoreEntryList == null)
        {
            highscores.highscoreEntryList = new List<HighscoreEntry>();
        }
        
        //add new entry to highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        
        if (highscores.highscoreEntryList.Count > 10) // addedin
        {
            for (int h = highscores.highscoreEntryList.Count; h>10; h--)
            {
                highscores.highscoreEntryList.RemoveAt(10);
            }
        }
        // save updated highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }
    
    // Represents a single High score entry
    [System.Serializable]
    private class HighscoreEntry
    {
        public string name;
        public int score;
        public float time;
        
    }
    

}
