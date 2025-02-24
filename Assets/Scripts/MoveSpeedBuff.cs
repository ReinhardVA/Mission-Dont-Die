using UnityEngine;

public class MoveSpeedBuff : MonoBehaviour{
    
    private float newMoveSpeed = 20f;
    private float newSpawnRate = 1f;
    private void Start(){
        
    }

    private void OnTriggerEnter2D(Collider2D collider){
        // saldırı hızını arttır ama düşman spawnı da artsın
        if(collider.TryGetComponent<PlayerAimWeapon>(out var player)){
            PlayerSoundManager.Instance.PlayerBuffSound();
            EnemySpawner.Instance.SetSpawnRate(newSpawnRate); 
            PlayerController.Instance.SetMoveSpeed(newMoveSpeed);
            Destroy(gameObject);
        }
    }
}
