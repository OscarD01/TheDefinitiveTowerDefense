using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Node : MonoBehaviour{
    public static Node selectedNode;
    private Animator animator;
    private bool isSelected = false;
    public bool isOcuped;
    public Turret turretOcuped;
    public Vector3 positionOffset;

    // private GameObject turret;

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown(){
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }
        if (isOcuped){
            TowerUIPanelManager.instance.OpenPanel(turretOcuped);
            return;
        }
        if (selectedNode && selectedNode != this){
            selectedNode.OnCloseSelection();
        }

        selectedNode = this;

        isSelected =! isSelected;
        if (isSelected){
            TowerRequestManager.instance.OnOpenRequestPanel();
        }
        else{
            TowerRequestManager.instance.OnCloseRequestPanel();
        }
        animator.SetBool("isSelected", isSelected);
    }

    public void OnCloseSelection(){
        isSelected = false;
        animator.SetBool("isSelected", isSelected);
    }
}
