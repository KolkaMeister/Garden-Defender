using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    [SerializeField] float timeToWait = 3f;
    public int currentScene;

     void Start()
     {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene==0)
        {
            StartCoroutine(WaitAndLoad("StartMenu"));
        }
     }
    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public IEnumerator WaitAndLoad(string nameOfScene)
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene(nameOfScene);
        Time.timeScale = 1;
    }
   public void LoadNextScene()
    {
        Time.timeScale = 1;
        if (SceneManager.sceneCountInBuildSettings <= currentScene + 1)
        {
            LoadStartMenu();
        }
        else
        {
            SceneManager.LoadScene(currentScene + 1);
        }

    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene);
    }
    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }
}
