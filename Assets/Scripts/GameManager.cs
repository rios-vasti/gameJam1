using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private int currentLevel;
    private float time;
    private float bestTime;
    public Text timeText;
    public Text playerBestTime;
    //load and unload scene 
    //SceneManager.LoadScene.("LevelName", LoadSceneMode.Single);

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        TimeSpan timetoDisplay = TimeSpan.FromSeconds(time);
        timeText.text = "Time: " + timetoDisplay.Minutes.ToString() + ":" + timetoDisplay.Seconds.ToString();
    }

    public void levelPassed()
    {
        //gets unloads the current sceene and loads the next level 

    }

    public void restartLevel()
    {

    }
}
