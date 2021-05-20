using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour{
    public Text moneyText;

    public GameObject TorretaMetralletaPanel;
    public GameObject MissileLauncherPanel;
    public GameObject LasserBeamerPanel;

    public Turret TorretaMetralleta;
    public Turret MissileLauncher;
    public Turret LasserBeamer;

    Image imgMetralleta;
    Image imgMissile;
    Image imgLasser;

    

    void Start(){
        imgMetralleta = TorretaMetralletaPanel.GetComponent<Image>();
        imgMissile = MissileLauncherPanel.GetComponent<Image>();
        imgLasser = LasserBeamerPanel.GetComponent<Image>();
    }
    void Update(){
        moneyText.text = PlayerStats.Money.ToString() + "$";
        check();
    }

    void check(){
        if (PlayerStats.Money >= TorretaMetralleta.buyPrice){
            imgMetralleta.color = UnityEngine.Color.green;
        }
        else{
            imgMetralleta.color = UnityEngine.Color.red;
        }
        if (PlayerStats.Money >= MissileLauncher.buyPrice){
            imgMissile.color = UnityEngine.Color.green;
        }
        else{
            imgMissile.color = UnityEngine.Color.red;
        }
        if (PlayerStats.Money >= LasserBeamer.buyPrice){
            imgLasser.color = UnityEngine.Color.green;
        }
        else{
            imgLasser.color = UnityEngine.Color.red;
        }
    }
}
