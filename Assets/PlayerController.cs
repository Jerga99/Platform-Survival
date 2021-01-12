using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float newHorizontalPosition = transform.position.x + horizontalInput * speed * Time.deltaTime;
        float newVerticalPosition = transform.position.z + verticalInput * speed * Time.deltaTime;

        transform.position = new Vector3(
            newHorizontalPosition,
            transform.position.y,
            newVerticalPosition);
    }
}
