using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelWon : MonoBehaviour{

    public Image img1;
    public Image img2;
    public Image img3;

    public SceneFader sceneFader;

    public int levelToUnlock = 2;
    public string nextLevel = "";

    void Start(){
        changeColor();
    }

    void Update(){
        
    }
    public void changeColor(){
        if (PlayerStats.Lives == 10){
            img1.GetComponent<Image>().color = new Color32(255, 213, 0, 255);
            img2.GetComponent<Image>().color = new Color32(255, 213, 0, 255);
            img3.GetComponent<Image>().color = new Color32(255, 213, 0, 255);
        }
        else if (PlayerStats.Lives < 10  &&  PlayerStats.Lives >= 5){
            img1.GetComponent<Image>().color = new Color32(255, 213, 0, 255);
            img2.GetComponent<Image>().color = new Color32(255, 213, 0, 255);
        }
        else{
            img1.GetComponent<Image>().color = new Color32(255, 213, 0, 255);
        }

    }
    public void Continue(){
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu(){
        sceneFader.FadeTo("Map");
    }
}
