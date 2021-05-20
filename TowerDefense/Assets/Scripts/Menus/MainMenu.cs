using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public SceneFader sceneFader;

    public void PlayGame()
    {
        sceneFader.FadeTo("SampleScene");
    }

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

}
