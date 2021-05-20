using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class TowerRequestManager : MonoBehaviour
{
    public List<Turret> turrets = new List<Turret>();
    private Animator animator;
    public static TowerRequestManager instance;
    public GameObject buildEffect;

    private Turret turret;


    private void Awake(){
        if (!instance){
            instance = this;
        }
        else{
            Destroy(instance);
        }
        animator = GetComponent<Animator>();
    }

    public void OnOpenRequestPanel(){
        animator.SetBool("isOpen", true);

    }

    public void OnCloseRequestPanel(){
        animator.SetBool("isOpen", false);
    }

    public void RequestTower(string turretName){
        turret = turrets.Find(x => x.turretName.Equals(turretName));
        if (PlayerStats.Money < turret.buyPrice){
            Debug.Log("No hay pasta");
            return;
        }
        PlayerStats.Money -= (int)turret.buyPrice;
        if (turretName.Equals("Lasser Beamer")){
            var turretGo = Instantiate(turret, Node.selectedNode.transform.position - new Vector3(0, 0.166f, 0), turret.transform.rotation);
        }
        else{
            var turretGo = Instantiate(turret, Node.selectedNode.transform.position, turret.transform.rotation);
        }
        
        GameObject effect = (GameObject)Instantiate(buildEffect, Node.selectedNode.transform.position + new Vector3(0,1,0), turret.transform.rotation);
        Destroy(effect, 5f);
        Node.selectedNode.turretOcuped = turret;
        Node.selectedNode.isOcuped = true;
        OnCloseRequestPanel();
        Node.selectedNode.OnCloseSelection();
        Node.selectedNode = null;    

        Debug.Log("Money Left" + PlayerStats.Money);
        //Destroy(turret, 1.0f);
        //Debug.Log("borrado");
    }

    public void DestroyTower()
    {
        //Destroy(Node.selectedNode.turretOcuped); 
        //turret.SetActive(false);
        Debug.Log("borrado");
    }
    

    
 
    
}
