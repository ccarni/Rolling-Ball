using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenUI : MonoBehaviour
{
    public string titleScreenName;
    public string tutorialSceneName;
    public Image backgroundImage;

    float minX, minY;
    float maxX, maxY;

    public Image onABun;
    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        StartCoroutine(FadeOut(100f, 20));
        SceneManager.LoadScene(tutorialSceneName);
    }

    public void Settings()
    {

    }

    public void Quit()
    {
        Application.Quit();        
    }

    IEnumerator FadeOut(float fadeTime, int numFrameChanges)
    {
        float frameInterval = numFrameChanges/fadeTime;
        Color color = backgroundImage.GetComponent<Image>().color;
        for(float i = 0; i <= fadeTime; i += frameInterval){
            color.a ++;
            backgroundImage.GetComponent<Image>().color = color;
            yield return new WaitForSeconds(frameInterval);
        }
    }

    public void LoadTitleScreen()
    {
        SceneManager.LoadScene(titleScreenName);
    }
}
