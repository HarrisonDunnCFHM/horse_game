using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    //config params
    [SerializeField] Text scoreText;
    [SerializeField] Text finalScoreText;
    [SerializeField] Text personalBest;

    //cached ref
    public int score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "HORSES FREED: " + score.ToString();
        finalScoreText.text = "HORSES FREED: " + score.ToString();
        personalBest.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    
    public void IncreaseScore()
    {
        score++;
        scoreText.text = "HORSES FREED: " + score.ToString();
        finalScoreText.text = "HORSES FREED: " + score.ToString();
        if (score > PlayerPrefs.GetInt("highscore") && !personalBest.gameObject.activeSelf)
        {
            personalBest.gameObject.SetActive(true);
        }
    }
}
