using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Script for Retry and Quit buttons.
//There is leftover junk data from an attempt to have a functioning stopwatch and saved best time.
//TODO: Create said stopwatch and best time save.
//Difficulty with PlayerPrefs, need to experiment and research more.

public class ResetGame : MonoBehaviour
{
    //public Text time;
    //public float timeValue;
    //float speed = 1;
    //public bool timeActive;
    //public PlayerCollector pC;

    public void restartGame()
    {
        //if (pC.didWin == true)
        //{
        //    PlayerPrefs.SetFloat("Time", timeValue);
        //}
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void returnToMenu()
    {
        //if (pC.didWin == true)
        //{
        //    PlayerPrefs.SetFloat("Time", timeValue);
        //}
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //void Update()
    //{
    //    if (timeActive == true)
    //    {
    //        timeValue += Time.deltaTime * speed;
    //        string hours = Mathf.Floor((timeValue % 216000) / 3600).ToString("00");
    //        string minutes = Mathf.Floor((timeValue % 3600) / 60).ToString("00");
    //        string seconds = (timeValue % 60).ToString("00");
    //        time.text = hours + ":" + minutes + ":" + seconds;
    //    }
    //}
}
