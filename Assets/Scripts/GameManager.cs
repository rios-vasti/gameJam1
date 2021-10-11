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
    //private static float bestTime = float.MaxValue;
    public Text timeText;
    public Text playerBestTime;
    public Text finalTime;
    public string[] levels = new string[] { "LevelOne", "LevelTwo", "LevelThree"}; 
    //load and unload scene 
    //SceneManager.LoadScene("LevelName", LoadSceneMode.Single);

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
        GameObject tmp = GameObject.FindGameObjectWithTag("Time");
        timeText = (tmp != null) ? tmp.GetComponent<Text>() : null;
        time = time + Time.deltaTime;
        TimeSpan timetoDisplay = TimeSpan.FromSeconds(time);
        if (timeText != null)
        {
            timeText.text = "Time: " + timetoDisplay.Minutes.ToString() + ":" + timetoDisplay.Seconds.ToString();
        }
        

 /*       if (bestTime != float.MaxValue)
        {
            TimeSpan bestTimeDisplay = TimeSpan.FromSeconds(bestTime);
            playerBestTime.text = "Best Time: " + bestTimeDisplay.Minutes.ToString() + ":" + bestTimeDisplay.Seconds.ToString();
        }*/

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
            
            /* if (finishTime < bestTime)
            {
                //bestTime = finishTime; 
            }*/
            currentLevel = 0;
            SceneManager.LoadScene("EndgameScreen", LoadSceneMode.Single);

            Invoke("delayedLoad", 1f);
        }
        

    }

    private void delayedLoad()
    {
        float finishTime = time-1;
        TimeSpan timetoDisplay = TimeSpan.FromSeconds(finishTime);
        time = 0;
        finalTime = GameObject.FindGameObjectWithTag("FinalTime").GetComponent<Text>();
        finalTime.text = "Your time was: " + timetoDisplay.Minutes.ToString() + ":" + timetoDisplay.Seconds.ToString();
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(levels[currentLevel], LoadSceneMode.Single);
    }
}
