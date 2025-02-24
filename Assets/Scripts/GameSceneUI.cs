using System;
using TMPro;
using UnityEngine;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI reloadText;
    [SerializeField] private HealthBar healthBar;
    private PlayerTakeDamage playerHealth;
    private void Start(){
        reloadText.enabled = false;
        playerHealth = FindAnyObjectByType<PlayerTakeDamage>();
        healthBar.SetSize(1f);
    }

    private void Update(){
        if(GameManager.Instance.GetPlayerState()){ // if player died
            reloadText.enabled = true;
            if(Input.GetKeyDown(KeyCode.R)){
                GameManager.Instance.RestartGame();
            }
        }
        healthBar.SetSize(playerHealth.GetHealth()/4);
    }
    
}
