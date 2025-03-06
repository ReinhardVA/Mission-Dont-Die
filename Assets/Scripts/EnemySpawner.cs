using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour{
    public static EnemySpawner Instance{get; private set;}
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform[] spawnPoints;
    private float spawnRate;
    private float nextSpawnTime;
    private void Awake(){
        Instance = this;
    }
    private void Start(){ 
        spawnRate = 1.75f;
    }
    private void Update(){
        
        SpawnEnemies(spawnRate);    
    }

    private void SpawnEnemies(float spawnRate){
        if(Time.time > nextSpawnTime){
            Transform spawnPoint = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab.gameObject, spawnPoint.position, Quaternion.identity);
            nextSpawnTime = Time.time + spawnRate;
        }
    }
    public void SetSpawnRate(float newSpawnRate){
        spawnRate = newSpawnRate;
    }
}
