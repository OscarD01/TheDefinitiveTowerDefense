using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour{
    public float initialSpeed;

    public float speed;

    public float startHealth = 100;
    private float health;

    public int money = 10;

    

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;


    void Awake(){
        speed = initialSpeed;
    }
    void Start(){
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getSpeed()
    {

    }

    public void TakeDamage(float amount){
        health -= amount;

        healthBar.fillAmount = health / startHealth;
        if(health <= 0 && !isDead){
            Die();
        }
    }

    public void Slow(float pct){
        speed = initialSpeed * (1f - pct);
    }
    void Die(){
        isDead = true;
        PlayerStats.Money += money;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);

        WaveSpawner.EnemiesAlive--;
        
        Destroy(gameObject);
    }
}
