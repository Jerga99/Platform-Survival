using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector2 spawnRange;

    private int m_EnemyCount;
    private int m_waves;

    // Start is called before the first frame update
    void Start()
    {
        m_waves = 1;
        //SpawnEnemy();   
    }

    private void Update()
    {
        m_EnemyCount = FindObjectsOfType<EnemyController>().Length;

        //if (m_EnemyCount == 0)
        //{
        //    m_waves++;
        //    SpawnEnemy();
        //}
    }

    private void SpawnEnemy()
    {
        for (var i = 0; i < m_waves; i++)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(spawnRange[0], spawnRange[1]),
                enemyPrefab.transform.position.y,
                Random.Range(spawnRange[0], spawnRange[1]));

            Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
        }
    }
}
