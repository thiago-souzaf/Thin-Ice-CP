using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().hasKey = true;
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.key);
            Destroy(gameObject);
        }
    }
}
