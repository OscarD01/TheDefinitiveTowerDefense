using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{

    private Transform target;

    public float speed = 70f;

    public int damage = 50;
    public float explosionRadius = 0f;
    public GameObject impactEffect;
    public void Seek(Transform target){

        this.target = target;

    }

    // Update is called once per frame
    void Update(){
        
        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame){
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget(){
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f){
            Explode();
        }
        else{
            Damage(target);
        }
        Destroy(gameObject);

    }

    void Damage (Transform enemy){
        Enemy e = enemy.GetComponent<Enemy>();
        if( e != null){
            e.TakeDamage(damage);
        }

    }

    void Explode(){
        int iterator = 0;
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders){
            if(collider.CompareTag("Enemy")){
                Damage(collider.transform);
            }
            if (iterator > 5){
                return;
            }
            iterator++;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
