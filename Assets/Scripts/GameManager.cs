using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject startScreen;

    private SpawnManager m_SpawnManager;

    // Start is called before the first frame update
    void Start()
    {
        m_SpawnManager = FindObjectOfType<SpawnManager>();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        m_SpawnManager.StartSpawning();
        startScreen.SetActive(false);
    }
}
