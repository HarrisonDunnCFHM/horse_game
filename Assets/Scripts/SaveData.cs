using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    [SerializeField] Text myScore;
    [SerializeField] Text personalBest;
    [SerializeField] Text myName;
    [SerializeField] int currentScore;
    

    private void Start()
    {
        currentScore = PlayerPrefs.GetInt("lastscore");

    }

    // Update is called once per frame
    void Update()
    {
        myScore.text = "HORSES FREED LAST GAME: " + currentScore.ToString();
        personalBest.text = "PERSONAL BEST: " + PlayerPrefs.GetInt("highscore") + " HORSES FREED";
    }

    public void SendScore()
    {
        if (currentScore > PlayerPrefs.GetInt("submittedscore"))
        {
            PlayerPrefs.SetInt("submittedscore", currentScore);
            HighScores.UploadScore(myName.text, currentScore);
        }
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
