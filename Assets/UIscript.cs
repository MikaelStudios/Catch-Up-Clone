using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIscript : MonoBehaviour
{
    GameObject player;
    float Speed;
    bool PlayEA = false;
    float _WaitTime;
    float _TImeChecker = 0f;
    float DefaultSpeed;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Speed = player.GetComponent<PlayerController>().SpeedOftheBall1;
        player.GetComponent<PlayerController>().SpeedOftheBall1 = 0f;
        DefaultSpeed = player.GetComponent<PlayerController>().SpeedOfRotation;

    }
    private void Update()
    {
        if (PlayEA == true) 
        {
            _TImeChecker += Time.deltaTime;
            player.GetComponent<PlayerController>().SpeedOfRotation += 5f;
            if (_TImeChecker >= _WaitTime) 
            {
                player.GetComponent<PlayerController>().SpeedOftheBall1 = Speed;
                player.GetComponent<PlayerController>().SpeedOfRotation = DefaultSpeed;
                PlayEA = false;
            }

        }
    }

    public void EntryANimation(float WaitTimer)
    {
        PlayEA = true;
        _WaitTime = WaitTimer;
    }
 
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Resume() 
    {
        Time.timeScale = 1f;
    }
    public void Restart() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);
    }
    public void Exit() 
    {
        Debug.Log("Nigga i am leaving you");
        Application.Quit();
    }

}
