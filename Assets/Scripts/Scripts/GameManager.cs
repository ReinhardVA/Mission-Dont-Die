using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    private bool isPlayerDied;
    private float survivalTime;
    private void Start(){
        Instance = this;
        isPlayerDied = false;
        survivalTime = 0f;
        PlayerTakeDamage player = FindAnyObjectByType<PlayerTakeDamage>(); // Finds the component in the scene
        if (player != null)
        {
            player.OnPlayerDied += GameManager_OnPlayerDied;
        }
        else
        {
            Debug.LogError("PlayerTakeDamage component not found in the scene!");
        }
    }
    private void Update(){
        if(!isPlayerDied){
            survivalTime += Time.deltaTime;
        }
    }

    private void GameManager_OnPlayerDied(object sender, PlayerTakeDamage.OnPlayerDiedEventArgs e)
    {
        isPlayerDied = e.isPlayerDied;
        GameOver();
    }

    private void GameOver()
    {
        Time.timeScale = 0;
    }

    public bool GetPlayerState(){
        return isPlayerDied;
    }
    public void RestartGame(){
        Time.timeScale = 1;
        Loader.Load(Loader.Scene.GameScene);
    }

    public float GetSurvivalTime(){
        return survivalTime;
    }
}
