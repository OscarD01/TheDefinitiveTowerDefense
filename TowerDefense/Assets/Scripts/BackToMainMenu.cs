using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMainMenu : MonoBehaviour{

    public SceneFader sceneFader;

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){

            sceneFader.FadeTo("MainMenu");
        }
    }
    public void click(){
        sceneFader.FadeTo("MainMenu");
    }
}
