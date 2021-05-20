using PathCreation;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public GameObject simpleEnemy;
    Enemy enemy;
    // public float speed = 50;
    float speed;
    float distanceTravelled;
    private float lenght;

    void Start(){
        
    }

    private void Awake(){
        enemy = simpleEnemy.GetComponent<Enemy>();
    }

    void Update(){
        distanceTravelled += enemy.speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
        lenght = pathCreator.path.length;
        if (distanceTravelled >= lenght){
            PlayerStats.Lives--;
            Destroy(gameObject);
            WaveSpawner.EnemiesAlive--;
        }
        enemy.speed = enemy.initialSpeed;

    }
}
