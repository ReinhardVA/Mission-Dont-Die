using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] buffPrefabs;
    [SerializeField] private Transform[] buffSpawnPoints;
    private float spawnRate = 10f;
    private float nextSpawnTime;

    private void Update(){
        SpawnBuffs(spawnRate);
    }
    private void SpawnBuffs(float spawnRate){
        if(Time.time > nextSpawnTime){
            Transform randomBuff = buffPrefabs[Random.Range(0, buffPrefabs.Length)];
            Transform spawnPoint = buffSpawnPoints[Random.Range(0, buffSpawnPoints.Length)];
            Instantiate(randomBuff, new Vector3(spawnPoint.position.x, spawnPoint.position.y, 0f), Quaternion.identity);
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
