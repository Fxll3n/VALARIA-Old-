using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float gridSize = 1f;
    public float moveSpeed = 5f;

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
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
            {
                Move(new Vector3(horizontalInput, verticalInput, 0f));
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

    public bool IsMoving()
    {
        return isMoving;
    }
}
