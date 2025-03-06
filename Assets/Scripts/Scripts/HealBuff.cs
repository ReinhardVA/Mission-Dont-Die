using UnityEngine;

public class HealBuff : MonoBehaviour{

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.TryGetComponent<PlayerTakeDamage>(out var player)){
            float currentHealth = player.GetHealth();
            PlayerSoundManager.Instance.PlayerBuffSound();
            if(currentHealth < 4f){
                currentHealth++;
                player.SetHealth(currentHealth);
            }
            PlayerController.Instance.SetMoveSpeed(7);
            Destroy(gameObject);
        }
    }

}
