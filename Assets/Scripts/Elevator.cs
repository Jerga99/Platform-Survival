using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    private float m_TravelDistance = 0;
    private float m_MaxTravelDistance = 15.0f;

    private float m_Speed = 5.0f;

    private Coroutine m_ReverseCoroutine;

    private IEnumerator Start()
    {
        enabled = false;
        yield return new WaitForSeconds(3.0f);
        enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (m_TravelDistance >= m_MaxTravelDistance)
        {
            if (m_ReverseCoroutine == null)
            {
                m_ReverseCoroutine = StartCoroutine(nameof(ReverseElevator));
            }
        } else
        {
            float distanceStep = m_Speed * Time.fixedDeltaTime;
            m_TravelDistance += Mathf.Abs(distanceStep);
            transform.Translate(0, distanceStep, 0);
        }
    }

    private IEnumerator ReverseElevator()
    {
        yield return new WaitForSeconds(3.0f);
        m_TravelDistance = 0;
        m_Speed = -m_Speed;
        m_ReverseCoroutine = null;
    }
}
