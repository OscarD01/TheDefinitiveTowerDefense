using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

    public Text livesText;
    private void Update(){
        if (PlayerStats.Lives == 1){
            livesText.text = PlayerStats.Lives.ToString() + " VIDA";
        }
        else{
            livesText.text = PlayerStats.Lives.ToString() + " VIDAS";
        }
    }
}
