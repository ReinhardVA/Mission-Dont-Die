using System;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour{
    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs{
        public Transform gunFirePointPosition;
        public Vector3 shootPosition;
    }
    [SerializeField] private Camera cam;
    [SerializeField] private Transform gunFirePointTransform;
    private void Update(){
        HandleAiming();
        HandleShooting();
    }

    private void HandleShooting()
    {
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            OnShoot?.Invoke(this, new OnShootEventArgs{
                gunFirePointPosition = gunFirePointTransform,
                shootPosition = mousePos
            });
        }
            
    }

    private void HandleAiming()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + 90f;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }
}
