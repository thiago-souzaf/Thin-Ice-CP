using UnityEngine;
using UnityEngine.Events;

public class SecretButton : MonoBehaviour
{
	public UnityEvent onButtonPress;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) { onButtonPress.Invoke(); }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            player.isOnSecretPart = false;

        }
    }
}
