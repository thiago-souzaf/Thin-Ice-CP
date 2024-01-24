using System.Collections;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public LayerMask notWalkable;
    private float speed = 7f;

    private float rayCastDistance = 0.5f;
	public void Throw(Vector3 direction)
	{
        StartCoroutine(Move(direction));
    }

	private IEnumerator Move(Vector3 direction)
	{
        while(CanMoveInDirection(direction))
        {
            transform.Translate(speed * Time.deltaTime * direction);
            yield return 0;
        }
    }

    bool CanMoveInDirection(Vector3 direction)
    {
        if (Physics2D.Raycast(transform.position, direction, rayCastDistance, notWalkable))
        {
            return false;
        }
        return true;
    }
}
