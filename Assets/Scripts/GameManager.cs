using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool m_IsGameActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        m_IsGameActive = true;
        Debug.Log("Starting the game!");
    }
}
