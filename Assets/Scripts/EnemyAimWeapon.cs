using UnityEngine;

public class EnemyAimWeapon : MonoBehaviour
{
    void Update()
    {
        Vector3 dir = (transform.position - PlayerController.Instance.GetPosition()).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }
}
