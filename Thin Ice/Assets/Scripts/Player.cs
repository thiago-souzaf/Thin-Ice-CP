using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement properties")]
    public float MoveDistance = 1f;
    public float MoveInterval = 0.15f;
    private float timeToMove;

    [Header("Layers")]
    public LayerMask notWalkable;
    public LayerMask interactable;

    [Header("Spawn Water")]
    public GameObject waterPrefab;

    [Header("Finish point")]
    public Transform finishPoint;

    public bool hasKey = false;
    public bool isOnThinIce = true;
    public bool isOnTopOfTeleporter = false;
    public bool isOnSecretPart = false;

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

        timeToMove = Time.time + MoveInterval;

        if (CheckInteractable(direction)) { return; }

        Vector2 oldPosition = transform.position;

        transform.Translate(MoveDistance * direction);
        
        if (!isOnTopOfTeleporter && !isOnSecretPart)
        {
            if (isOnThinIce)
            {
                AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.thinIceBreak);
                Instantiate(waterPrefab, oldPosition, Quaternion.identity);
            }
            GameManager.Instance.PlayerPoints += 1;
            GameManager.Instance.IcesMelted += 1;
        }

        if (transform.position == finishPoint.position)
        {
            Debug.Log("Level finished");
            GameManager.Instance.NextLevel();
            return;
        }
        if (!CanMoveInAnyDirection())
        {
            // Die and restart level
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.playerDead);
            GetComponent<Animator>().SetBool("Dead", true);
            Instantiate(waterPrefab, transform.position, Quaternion.identity);
            GameManager.Instance.Invoke(nameof(GameManager.Instance.RestartLevel), 0.5f);
        }
    }
    bool CanMoveInDirection(Vector3 direction)
    {
        if (Physics2D.Raycast(transform.position, direction, MoveDistance, notWalkable))
        {
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

    bool CheckInteractable(Vector3 direction)
    {
        RaycastHit2D hitInteractable = Physics2D.Raycast(transform.position, direction, MoveDistance, interactable);
        if (hitInteractable)
        {
            string hitTag = hitInteractable.collider.tag;
            if (hitTag == "KeySocket" && hasKey)
            {
                hitInteractable.collider.gameObject.GetComponent<KeySocket>().Open();
            }

            if (hitTag == "MovingBlock")
            {
                hitInteractable.collider.gameObject.GetComponent<MovingBlock>().Throw(direction) ;
            }
            return true;
        }
        return false;
    }

}
