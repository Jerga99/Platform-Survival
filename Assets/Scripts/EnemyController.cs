using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;

    private Rigidbody m_Rb;
    private GameObject m_FollowTarget;

    private void Awake()
    {
        m_Rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        m_FollowTarget = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveTowards = (m_FollowTarget.transform.position - transform.position).normalized;
        moveTowards.y = 0;
        m_Rb.AddForce(moveTowards * speed);
    }
}
