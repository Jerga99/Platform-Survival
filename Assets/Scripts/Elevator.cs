using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    private float m_AccuTime = 0;
    private float m_RunnigTime = 3.0f;
    private float m_Speed = 5.0f;

    private Coroutine m_ReverseCoroutine;


    // Update is called once per frame
    void Update()
    {
        m_AccuTime += Time.deltaTime;

        if (m_AccuTime >= m_RunnigTime)
        {
            if (m_ReverseCoroutine == null)
            {
                m_ReverseCoroutine = StartCoroutine(nameof(ReverseElevator));
            }
        } else
        {
            transform.Translate(0, m_Speed * Time.deltaTime, 0);
        }
    }

    private IEnumerator ReverseElevator()
    {
        Debug.Log("Calling ReverseElevator");
        yield return new WaitForSeconds(3.0f);
        // we will wait 3 second until this code is executed
        m_AccuTime = 0;
        m_Speed = -m_Speed;
        m_ReverseCoroutine = null;
    }
}
