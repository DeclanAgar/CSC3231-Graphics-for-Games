using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotationSpeed;

    private float yaw;
    private float pitch;

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) // Move camera forward
        {
            transform.position += moveSpeed * transform.forward;
        }
        if (Input.GetKey(KeyCode.A)) // Move camera to the left
        {
            transform.position += moveSpeed * (transform.right *- 1);
        }
        if (Input.GetKey(KeyCode.S)) // Move camera backwards
        {
            transform.position += moveSpeed * (transform.forward * -1);
        }
        if (Input.GetKey(KeyCode.D)) // Move camera to the right
        {
            transform.position += moveSpeed * transform.right;
        }
        if (Input.GetKey(KeyCode.Space)) // Move camera up
        {
            transform.position += moveSpeed * transform.up;
        }
        if (Input.GetKey(KeyCode.C)) // Move camera down
        {
            transform.position += moveSpeed * (transform.up * -1);
        }

        // Camera rotation
        yaw += rotationSpeed * Input.GetAxisRaw("Mouse X");
        pitch += rotationSpeed * Input.GetAxisRaw("Mouse Y");
        transform.eulerAngles = new Vector3(-pitch, yaw, 0.0f);
    }
}