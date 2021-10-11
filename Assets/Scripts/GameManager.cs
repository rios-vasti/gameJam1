using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private static int currentLevel = 0;
    private static float time = 0;
    private static float bestTime = float.MaxValue;
    public Text timeText;
    public Text playerBestTime;
    public string[] levels = new string[] { "LevelOne", "LevelTwo", "LevelThree"}; 
    //load and unload scene 
    //SceneManager.LoadScene("LevelName", LoadSceneMode.Single);

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        TimeSpan timetoDisplay = TimeSpan.FromSeconds(time);
        timeText.text = "Time: " + timetoDisplay.Minutes.ToString() + ":" + timetoDisplay.Seconds.ToString();

        if (bestTime != float.MaxValue)
        {
            TimeSpan bestTimeDisplay = TimeSpan.FromSeconds(bestTime);
            playerBestTime.text = "Best Time: " + bestTimeDisplay.Minutes.ToString() + ":" + timetoDisplay.Seconds.ToString();
        }

    }

    public void levelPassed()
    {
        currentLevel += 1;
        if (currentLevel < levels.Length)
        {
            SceneManager.LoadScene(levels[currentLevel], LoadSceneMode.Single);
            
        }
        else
        {
            Debug.Log("Finished the levels"); 
            float finishTime = time;
            TimeSpan timetoDisplay = TimeSpan.FromSeconds(finishTime);
            if (finishTime < bestTime)
            {
                bestTime = finishTime; 
            }
            //remove the loop to the current level
            currentLevel = 0;
            SceneManager.LoadScene(levels[currentLevel], LoadSceneMode.Single);
            // call finish screen
            //display the finishTime 
        }
        

    }

    public void restartLevel()
    {
        SceneManager.LoadScene(levels[currentLevel], LoadSceneMode.Single);
    }
}
