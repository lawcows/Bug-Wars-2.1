using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 2.0f;
    public float enemyCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnInterval, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {   
        int i = 0;
        i++;
        if(i <= enemyCount)
        {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject gameObject1 = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else return;
    }
}
