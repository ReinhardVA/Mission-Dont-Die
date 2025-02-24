using System;
using UnityEngine;

public class PlayerFireProjectiles : MonoBehaviour
{
    [SerializeField] private Transform bulletPrefab;
    private void Awake()
    {
        GetComponent<PlayerAimWeapon>().OnShoot += PlayerFireProjectiles_OnShoot;
    }

    private void PlayerFireProjectiles_OnShoot(object sender, PlayerAimWeapon.OnShootEventArgs e)
    {
        Transform bulletTransform = Instantiate(bulletPrefab, e.gunFirePointPosition.position, e.gunFirePointPosition.rotation);
        CameraShake.Instance.ShakeCamera(7f, .1f);
        Vector3 shootDir = (e.shootPosition - e.gunFirePointPosition.position).normalized;
        PlayerSoundManager.Instance.PlayFireSound();
        bulletTransform.GetComponent<BulletPhysics>().FireBullet(shootDir);
    }
}
