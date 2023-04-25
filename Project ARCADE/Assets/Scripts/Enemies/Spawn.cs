using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 2.0f;
    public int enemyCount = 3;
    int enemyIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnEnemy()
    {   
        yield return new WaitForSecondsRealtime (spawnInterval);
        enemyIndex++;
        if(enemyIndex <= enemyCount)
        {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject gameObject1 = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        StartCoroutine(SpawnEnemy());
        }
    }
}
