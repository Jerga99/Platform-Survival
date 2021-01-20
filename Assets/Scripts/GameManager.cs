using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool m_IsGameActive = false;
    private SpawnManager m_SpawnManager;

    // Start is called before the first frame update
    void Start()
    {
        m_SpawnManager = FindObjectOfType<SpawnManager>();
    }

    public void StartGame()
    {
        m_IsGameActive = true;
        m_SpawnManager.StartSpawning();
    }
}
