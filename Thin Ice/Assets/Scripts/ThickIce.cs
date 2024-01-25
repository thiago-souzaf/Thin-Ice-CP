using UnityEngine;

public class ThickIce : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().isOnThinIce = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().isOnThinIce = true;
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.thickIceBreak);
            Destroy(gameObject);
        }
    }
}
