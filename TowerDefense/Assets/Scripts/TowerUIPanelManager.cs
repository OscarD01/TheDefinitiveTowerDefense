using UnityEngine;
using TMPro;

public class TowerUIPanelManager : MonoBehaviour{
    private Turret turret;
    public TextMeshProUGUI turretNameText;
    public TextMeshProUGUI turretDescriptionText;
    public TextMeshProUGUI turretRangeText;
    public TextMeshProUGUI turretDMGText;
    public TextMeshProUGUI turretVelocityText;
    public TextMeshProUGUI turretSellPriceText;
    public TextMeshProUGUI turretUpgradePriceText;
    public GameObject root;

    public static TowerUIPanelManager instance;
    private void Awake()
    {
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(this);
        }
    }

    public void OpenPanel(Turret turret){
        if (turret == null) {
            Debug.Log("Es necesario pasar un tower");
            return;
        }
        this.turret = turret;
        SetValues();
        root.SetActive(true);
    }
    private void SetValues(){
        turretNameText.text = turret.turretName;
        turretDescriptionText.text = turret.turretDescription;
        turretRangeText.text = "Rango: " + turret.range.ToString();
        turretDMGText.text = "Daño: " + turret.dmg.ToString();
        turretVelocityText.text = "Cadencia: " + turret.turnSpeed.ToString();
        turretSellPriceText.text = turret.sellPrice.ToString() + "$";
        turretUpgradePriceText.text = turret.upgradePrice.ToString() + "$";
    }
    public void ClosePanel()
    {
        root.SetActive(false);
    }
}
