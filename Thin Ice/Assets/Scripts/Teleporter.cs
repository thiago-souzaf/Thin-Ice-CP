using UnityEngine;
using UnityEngine.Events;

public class Teleporter : MonoBehaviour
{
    public string teleporterID;

    public UnityEvent<string> OnTeleportUse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnTeleportUse.Invoke(teleporterID);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().isOnTopOfTeleporter = false;
        }
    }
}
