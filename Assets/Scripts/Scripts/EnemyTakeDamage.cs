using System;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
    private float enemyHealth = 3f;
    private BulletPhysics bullet;
    private void OnTriggerEnter2D(Collider2D collider)
    {  
        bullet = collider.GetComponent<BulletPhysics>();
        if(bullet != null){
            Damage();
        }
    }
    private void Damage(){
        enemyHealth--;
        if(enemyHealth <= 0){
            Destroy(gameObject);
        }
    }
}
