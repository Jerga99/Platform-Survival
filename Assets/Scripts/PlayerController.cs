using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GameObjectEfx
{
    public static void DrawCircle(this GameObject container)
    {
        var lineRenderer = container.AddComponent<LineRenderer>();

        Vector3 pointA = new Vector3(0, 0, 0);
        Vector3 pointB = new Vector3(20, 0, 0);

        var points = new Vector3[2];
        points[0] = pointA;
        points[1] = pointB;
        lineRenderer.SetPositions(points);
    }
}



public class PlayerController : MonoBehaviour
{
    public float speed;
    public Camera followCamera;

    private Rigidbody m_Rb;
    private GameObject m_Elevator;
    private float m_ElevatorOffsetY;
    private Vector3 m_CameraPos;
    private float m_SpeedModifier;

    private void Awake()
    {
        GameObject go = new GameObject {
            name = "Circle"
        };
        Vector3 circlePosition = Vector3.zero;

        go.transform.parent = transform;
        go.transform.localPosition = circlePosition;

        go.DrawCircle();

        m_Rb = GetComponent<Rigidbody>();
        
        m_ElevatorOffsetY = 0;
        m_SpeedModifier = 1;

        m_CameraPos = followCamera.transform.position - m_Rb.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 playerPos = m_Rb.position;
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (movement == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(movement);
        
        if (m_Elevator != null)
        {
            playerPos.y = m_Elevator.transform.position.y + m_ElevatorOffsetY;
        }

        targetRotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            360 * Time.fixedDeltaTime);

        m_Rb.MovePosition(playerPos + movement * m_SpeedModifier * speed * Time.fixedDeltaTime);
        m_Rb.MoveRotation(targetRotation);
    }

    private void LateUpdate()
    {
        followCamera.transform.position = m_Rb.position + m_CameraPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Powerup"))
        {
            Destroy(collision.gameObject);
            m_SpeedModifier = 2;
            StartCoroutine(BonusSpeedCountdown());
        }

        if (collision.gameObject.CompareTag("Enemy") && m_SpeedModifier > 1)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * 20.0f, ForceMode.Impulse);
        }
    }

    private IEnumerator BonusSpeedCountdown()
    {
        yield return new WaitForSeconds(20.0f);
        m_SpeedModifier = 1;
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
