using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveDistance = 1f;
    public float moveInterval = 0.2f;

    public LayerMask notWalkable;

    public GameObject waterPrefab;

    private float timeToMove;

    public Vector3 oldPosition;
    public Transform finishPoint;

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (timeToMove < Time.time)
        {
            if (horizontalInput != 0)
            {
                Move(Mathf.Sign(horizontalInput) * Vector3.right);
            } else if (verticalInput != 0)
            {
                Move(Mathf.Sign(verticalInput) * Vector3.up);
            }
        }
    }
    void Move(Vector3 direction)
    {
        if (!CanMoveInDirection(direction)) { return; }

        Vector2 oldPosition = transform.position;
        transform.Translate(moveDistance *  direction);
        timeToMove = Time.time + moveInterval;
        Instantiate(waterPrefab, oldPosition, Quaternion.identity);

        if (transform.position == finishPoint.position)
        {
            Debug.Log("Level finished");
            GameManager.Instance.NextLevel();
            return;
        }
        if (!CanMoveInAnyDirection())
        {
            GameManager.Instance.RestartLevel();
            Debug.Log("Game over");
        }
    }
    bool CanMoveInDirection(Vector3 direction)
    {
        
        if (Physics2D.Raycast(transform.position, direction, moveDistance, notWalkable)){
            return false;
        }
        return true;
    }
    bool CanMoveInAnyDirection()
    {
        if (CanMoveInDirection(Vector2.up)) { return true; }
        if (CanMoveInDirection(Vector2.right)) { return true; }
        if (CanMoveInDirection(Vector2.down)) { return true; }
        if (CanMoveInDirection(Vector2.left)) { return true; }
        return false;
    }

}
