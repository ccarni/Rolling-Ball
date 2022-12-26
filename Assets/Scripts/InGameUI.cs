using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public Canvas deathScreen;
    public Canvas pauseScreen;
    public Canvas victoryScreen;
    public string mainMenuSceneName = "MainMenu";
    // Start is called before the first frame update
    private void Awake()
    {
        deathScreen.GetComponent<Canvas>().enabled = false;
        pauseScreen.GetComponent<Canvas>().enabled = false;    
        victoryScreen.GetComponent<Canvas>().enabled = false;       

        Application.targetFrameRate = 60;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDeathScreen()
    {
        deathScreen.GetComponent<Canvas>().enabled = true;
    }

    public void ShowPauseScreen()
    {
        pauseScreen.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0;
    }

    public void HidePauseScreen()
    {
        pauseScreen.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
    }

    public void ShowVictoryScreen()
    {
        victoryScreen.GetComponent<Canvas>().enabled = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
