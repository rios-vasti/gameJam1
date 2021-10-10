using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUIController : MonoBehaviour
{
    public void DisplayRules()
    {
        SceneManager.LoadScene("RulesScene", LoadSceneMode.Additive);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("LevelOne", LoadSceneMode.Single);
    }
    public void CloseRules()
    {
        SceneManager.UnloadSceneAsync("RulesScene");
    }
    public void DisplayHighscore()
    {
        
    }
    public void DisplayMainMenu()
    {
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }
}
