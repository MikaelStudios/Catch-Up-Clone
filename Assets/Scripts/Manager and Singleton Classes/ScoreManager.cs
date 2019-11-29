using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _ScoreInstance;
    public static ScoreManager ScoreInstance
    {
        get
        {
            if (_ScoreInstance == null)
            {
                Debug.Log("There is no Score Manager");
            }
            return _ScoreInstance;
        }
    }
    public int Coins { get; set; }
    int CoinsAfterPlay = 0;
    public GameObject player;
    public TextMeshProUGUI ScoreText;
    float Score = 0;
    float HighScore = 0;
    private bool isGameOver;
    public GameObject GameOverpanel;
    public TextMeshProUGUI GOscore;
    public TextMeshProUGUI GOHhighscore;

    private void Awake()
    {
        _ScoreInstance = this;
        Coins = PlayerPrefs.GetInt("Coins");
    }
    public bool IsGameOver
    {
        get => isGameOver;
        set 
        {
         isGameOver = value;
        if (IsGameOver == true)
            {
                //  Mikael remember stuff like Celebration, the pause button
                GameOverpanel.SetActive(true);
                GOscore.SetText(Score.ToString());
                Coins = PlayerPrefs.GetInt("Coins");
                HighScore = PlayerPrefs.GetFloat("HighScore");
                PlayerPrefs.SetInt("Coins", (CoinsAfterPlay + Coins));
                PlayerPrefs.Save();
                if (Score >= HighScore)
                {
                    PlayerPrefs.SetFloat("HighScore", Score);
                    PlayerPrefs.Save();
                    HighScore = PlayerPrefs.GetFloat("HighScore");
                }
                GOHhighscore.SetText(HighScore.ToString());
                DebugLog();
                if (player != null)
                {
                    DecalPainter.Instance.Paint(player.transform.position + new Vector3(0, 0, Random.Range(-2, 1)), Color.white, Random.Range(4, 8));
                }
                player.gameObject.SetActive(false);
                Time.timeScale = 0f;
            }
        }
    }

    private void DebugLog()
    {
        Debug.Log("the coins you gained is :" + CoinsAfterPlay);
        Debug.Log("Total coins= " + Coins);
    }

    public void GameOver()
    {
        IsGameOver = true;
        
    }

    public void ScoreUpdate() 
    {
        Score++;
        ScoreText.SetText(Score.ToString());
    }

    public void CoinIncrement() 
    {
        CoinsAfterPlay++;
    }
}
