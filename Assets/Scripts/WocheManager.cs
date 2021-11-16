using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WocheManager : MonoBehaviour
{

    public int days;
    public int week = 7;
    public int weeklyScore;
    public int figureScore;
    public int cupScore;
    public int horsieScore;

    public List<Item> toybin;
    public GameObject bed;
    public Player player;

    [Header("UI Objects")]
    public GameObject ScoreUI;
    public Text figureScoreText;
    public Text cupScoreText;
    public Text horsieScoreText;
    public Text totalScoreText;
    public GameObject goodJobText;


    public void Start()
    {
    }
    
    public void EndDay()
    {
        days += 1;
        player.beenOutside = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bed = GameObject.Find("Bed");
            if (bed.GetComponent<AtBed>().atBed)
            {
                if (days > week)
                {
                    EndWeek();    
                }
                else
                {
                    EndDay();
                }
            }
        }
    }

    private void EndWeek()
    {
        days = 0;
        figureScore = 0;
        cupScore = 0;
        horsieScore = 0;
        weeklyScore = 0;
        
        toybin = GameObject.Find("StorageManager").GetComponent<StorageManager>().toys;
        for (int i = 0; i < toybin.Count; i++)
        {
            switch (toybin[i].itemName)
            {
                case "Wooden Figure":
                    figureScore += toybin[i].score;
                    break;
                case "BallNCup":
                    cupScore += toybin[i].score;
                    break;
                case "Rocking Horse":
                    horsieScore += toybin[i].score;
                    break;
            }
        }

        weeklyScore = figureScore + cupScore + horsieScore;

        figureScoreText.text = figureScore.ToString();
        cupScoreText.text = cupScore.ToString();
        horsieScoreText.text = horsieScore.ToString();
        totalScoreText.text = weeklyScore.ToString();
        
        if (weeklyScore >= 1500)
        {
            goodJobText.SetActive(true);
        }
        
        ScoreUI.SetActive(true);
    }

    public void CloseScoreUI()
    {
        ScoreUI.SetActive(false);
        goodJobText.SetActive(false);
    }

}
