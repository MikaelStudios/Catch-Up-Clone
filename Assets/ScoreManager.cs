using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private TextMeshProUGUI ScoreText;
    float Score = 0;
    float HighScore = 0;
    PlayerController PC;
    private bool isGameOver;
    public GameObject GameOverpanel;
    public TextMeshProUGUI GOscore;
    public TextMeshProUGUI GOHhighscore;
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
                HighScore = PlayerPrefs.GetFloat("HighScore");
                if (Score >= HighScore) 
                {
                    PlayerPrefs.SetFloat("HighScore", Score);
                    PlayerPrefs.Save();
                    HighScore = PlayerPrefs.GetFloat("HighScore");
                }
                GOHhighscore.SetText(HighScore.ToString());
                Time.timeScale = 0f;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PC = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Time.timeScale > 0.8f ) 
        {
            Score +=( 1 * Time.deltaTime );
            ScoreText.SetText(Score.ToString());
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            IsGameOver = true;
        }
    }

    public void ScoreUpdate(int ScoreMultiplier) 
    {
        Score += ScoreMultiplier;
        ScoreText.SetText(Score.ToString());
    }
}
