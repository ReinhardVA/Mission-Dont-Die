using System;
using TMPro;
using UnityEngine;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI reloadText;
    [SerializeField] private TextMeshProUGUI survivalTimeText;
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
        survivalTimeText.text = "Time Alive: " + FormatTime(GameManager.Instance.GetSurvivalTime());
        healthBar.SetSize(playerHealth.GetHealth()/4);
    }
    private string FormatTime(float time){
        int minutes = Mathf.FloorToInt(time/60);
        int seconds = Mathf.FloorToInt(time%60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
