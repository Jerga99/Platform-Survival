using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector2 spawnRange;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();   
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnRange[0], spawnRange[1]),
            enemyPrefab.transform.position.y,
            Random.Range(spawnRange[0], spawnRange[1]));

        Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
    }
}
