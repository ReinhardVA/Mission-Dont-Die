using UnityEngine;

public class BulletPhysics : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;

    public void FireBullet(Vector3 shootDir){
        float moveSpeed = 100f;
        rb2d.AddForce(shootDir * moveSpeed, ForceMode2D.Impulse);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {   
        Destroy(gameObject);
    }
    private void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
