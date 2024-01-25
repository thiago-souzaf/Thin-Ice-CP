using UnityEngine;

public class KeySocket : MonoBehaviour
{
	public void Open()
	{
		AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.key);
		Destroy(gameObject);
	}
}
