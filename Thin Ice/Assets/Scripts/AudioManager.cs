using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region Singleton setup
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if ( Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    #endregion


    [Header("Audio sources")]
	[SerializeField] private AudioSource musicSource;
	[SerializeField] private AudioSource soundSource;

	[Header("Audio Clips")]
    public AudioClip backgroundMusic;

	public AudioClip movingBlock;
	public AudioClip key;
    public AudioClip levelComplete;
    public AudioClip levelStart;
    public AudioClip playerDead;
    public AudioClip teleport;
    public AudioClip thickIceBreak;
    public AudioClip thinIceBreak;
    public AudioClip treasureGet;

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }
}
