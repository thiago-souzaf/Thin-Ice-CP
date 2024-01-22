using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveDistance = 1f;
    public float moveInterval = 0.2f;
    private float timeToMove;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        if (timeToMove < Time.time)
        {
            if (horizontalInput != 0)
            {
                rb.MovePosition(transform.position + moveDistance * Mathf.Sign(horizontalInput) * Vector3.right);
                timeToMove = Time.time + moveInterval;
            } else if (verticalInput != 0)
            {
                rb.MovePosition(transform.position + moveDistance * Mathf.Sign(verticalInput) * Vector3.up);
                timeToMove = Time.time + moveInterval;
            }
            
        }
    }
}
