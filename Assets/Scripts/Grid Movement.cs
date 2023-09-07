using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float gridSize = 1f; // Adjust this to your grid size
    public float moveSpeed = 5f; // Adjust this to your desired movement speed
    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Start()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Move(Vector3.up);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Move(Vector3.down);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Move(Vector3.left);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                Move(Vector3.right);
            }
        }
    }

    private void Move(Vector3 direction)
    {
        targetPosition = transform.position + direction * gridSize;
        isMoving = true;
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.fixedDeltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false;
            }
        }
    }
}
