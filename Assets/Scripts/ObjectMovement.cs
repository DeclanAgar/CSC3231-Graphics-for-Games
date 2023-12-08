using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private GameObject parent;

    // If rotation value is 1, object will rotate on respective axis
    [SerializeField, Range(0, 1)]
    private int xRotation;
    [SerializeField, Range(0, 1)]
    private int yRotation;
    [SerializeField, Range(0, 1)]
    private int zRotation;

    // Movement variables
    [SerializeField]
    private bool move;
    [SerializeField]
    private float moveSpeed;

    private float moveTimer = 0f;
    private Vector3 originalPosition;
    private Vector3 movementPosition;

    private void Start()
    {
        // Get original and movement position vectors
        originalPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        movementPosition = new Vector3(originalPosition.x, originalPosition.y + 5f, originalPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously running timer
        moveTimer += Time.deltaTime;

        if (moveTimer > 2)
        {
            moveTimer = 0f;
        }
    }

    void FixedUpdate()
    {
        // If object set to move, move up and down
        if (move == true)
        {
            if (moveTimer < 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, movementPosition, moveSpeed * Time.deltaTime);
                transform.Rotate(new Vector3(xRotation, yRotation, zRotation));
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
                transform.Rotate(new Vector3(xRotation, yRotation, zRotation));
            }
        }
        // If parent is assigned, set to rotate around itself (for the rune of the magical anomaly which is the root of the feature)
        else if (parent != null) {
            transform.RotateAround(parent.transform.position, new Vector3(xRotation, yRotation, zRotation), rotationSpeed * Time.deltaTime);
        }
        // Else rotate around parent in hierarchy
        else
        {
            transform.RotateAround(transform.parent.position, new Vector3(xRotation, yRotation, zRotation), rotationSpeed * Time.deltaTime);
        }
    }
}
