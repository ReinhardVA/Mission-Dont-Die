using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerTakeDamage : MonoBehaviour
{
    public event EventHandler<OnPlayerDiedEventArgs> OnPlayerDied;
    public class OnPlayerDiedEventArgs : EventArgs{
        public bool isPlayerDied;
    }
    private float health = 4f;
    private bool isPlayerDied = false;
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<BulletPhysics>(out var bulletPhysics)){
            health--;
            PlayerSoundManager.Instance.PlayHurtSound();
            if(health <= 0){
                isPlayerDied = true;
                OnPlayerDied?.Invoke(this, new OnPlayerDiedEventArgs{
                    isPlayerDied = isPlayerDied
                });
            }
        }
    }

    public void SetHealth(float newHealth){
        health = newHealth;
    }
    public float GetHealth(){
        return health;
    }
}
