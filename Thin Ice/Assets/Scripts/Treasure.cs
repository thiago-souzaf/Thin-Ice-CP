using UnityEngine;

public class Treasure : MonoBehaviour
{
    [SerializeField] int treasurePoints = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.PlayerPoints += treasurePoints;
            GameManager.Instance.coinBagsCollected++;
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.treasureGet);
            Destroy(gameObject);
        }
    }
}
