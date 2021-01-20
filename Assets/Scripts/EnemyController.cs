using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float pushRadius;

    private Rigidbody m_Rb;
    private GameObject m_FollowTarget;

    private void Awake()
    {
        AddCircle();
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

        if (transform.position.y <= -15.0f)
        {
            Destroy(gameObject);
        }
    }

    void AddCircle()
    {
        GameObject go = new GameObject
        {
            name = "Circle"
        };
        Vector3 circlePosition = Vector3.zero;
        circlePosition.y = -0.49f;

        go.transform.parent = transform;
        go.transform.localPosition = circlePosition;

        go.DrawCircle(pushRadius, .02f);
    }
}
