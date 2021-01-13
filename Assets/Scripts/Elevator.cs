using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    private float m_AccuTime = 0;
    private float m_RunnigTime = 3.0f;
    private float m_Speed = 5.0f;


    // Update is called once per frame
    void Update()
    {
        m_AccuTime += Time.deltaTime;

        if (m_AccuTime >= m_RunnigTime)
        {
            ReverseElevator();
        } else
        {
            transform.Translate(0, m_Speed * Time.deltaTime, 0);
        }
    }

    private void ReverseElevator()
    {
        m_AccuTime = 0;
        m_Speed = -m_Speed;
    }
}
