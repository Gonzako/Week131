using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManagement : MonoBehaviour
{
  
    public void LoadMainMenu()
    {
        SceneManager.GetSceneByName("Main Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
