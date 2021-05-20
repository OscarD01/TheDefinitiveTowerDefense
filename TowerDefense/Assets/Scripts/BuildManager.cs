using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour{

    public static BuildManager instance;

    void Awake(){
        if (instance != null){
            Debug.Log("More than one build manager in scene");
            return;
        }
        instance = this;
    }

    public GameObject torretaMetralletaPrefab;

    private GameObject turretToBuild;

    public void BuildTorretaMetralleta(){
        Instantiate(torretaMetralletaPrefab, transform.position, transform.rotation);
    }

}
