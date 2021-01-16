using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody m_Rb;
    private GameObject m_Elevator;
    private float m_ElevatorOffsetY;

    private void Awake()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_ElevatorOffsetY = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 playerPos = m_Rb.position;
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        movement.Normalize();

        if (m_Elevator != null)
        {
            playerPos.y = m_Elevator.transform.position.y + m_ElevatorOffsetY;
        }

        m_Rb.MovePosition(playerPos + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Elevator"))
        {
            m_Elevator = other.gameObject;
            m_ElevatorOffsetY = transform.position.y - m_Elevator.transform.position.y;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Elevator"))
        {
            m_Elevator = null;
            m_ElevatorOffsetY = 0;
        }
    }
}
