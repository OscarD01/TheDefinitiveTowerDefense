using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform spawnPoint;

    public float timeBetwenWaves = 5f;
    private float countdown = 2f;
    private int waveIndex = 0;

    public Text waveCountdownText;
    void Update(){
        if(EnemiesAlive > 0){
            return;
        }
        if (countdown <= 0){
            StartCoroutine(SpawnWave());
            countdown = timeBetwenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
        
    }


    IEnumerator SpawnWave(){
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];
        
        for (int i = 0; i < wave.count; i++){
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
    }

    void SpawnEnemy(GameObject enemy){
        Instantiate(enemy, transform.position, transform.rotation);
        EnemiesAlive++;
    }
}
