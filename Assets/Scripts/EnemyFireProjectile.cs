using System;
using UnityEngine;

public class EnemyFireProjectile : MonoBehaviour
{
    [SerializeField] private Transform bulletPrefab;
    private void Awake(){
        GetComponent<EnemyAI>().OnEnemyFire += EnemyFireProjectiles_OnEnemyFire;
    }

    private void EnemyFireProjectiles_OnEnemyFire(object sender, EnemyAI.OnEnemyFireEventArgs e)
    {
        Transform bulletTransform = Instantiate(bulletPrefab, e.gunFirePointPosition.position, e.gunFirePointPosition.rotation);
        Vector3 shootDir = (e.shootPosition - e.gunFirePointPosition.position).normalized;
        bulletTransform.GetComponent<BulletPhysics>().FireBullet(shootDir);
    }
}
