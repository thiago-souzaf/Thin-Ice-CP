using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton setup
    public static GameManager Instance {  get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }

    #endregion

    [field:SerializeField] public int CurrentLevel { get; private set; }
    [field: SerializeField] public int LevelsSolved { get; private set; }
    [field: SerializeField] public int AmountOfIces { get; private set; }

    private int _icesMelted;
    public int IcesMelted
    {
        get { return _icesMelted; }
        set
        {
            _icesMelted = value;
            icesMeltedChanged.Invoke(_icesMelted);
        }
    }
    private int _playerPoints;
    public int PlayerPoints
    {
        get
        {
            return _playerPoints;
        }
        set
        {
            _playerPoints = value;
            pointsChanged.Invoke(_playerPoints);
        }
    }

    private int pointsAtLevelStart;

    public int[] icesPerLevel = new int[] { 12, 19, 25, 43, 41, 41, 66, 82, 93, 208, 132, 138, 128, 131, 227, 181, 161, 179, 172};

    public UnityEvent<int> pointsChanged;
    public UnityEvent<int> icesMeltedChanged;

    public int coinBagsCollected = 0; // coin bags collected per level
    public int totalCoinBagsCollected = 0; // total bags collected on game
    public int totalIceMelted = 0;

    private void Start()
    {
        CurrentLevel = 1;
        AmountOfIces = icesPerLevel[CurrentLevel - 1];
        IcesMelted = 0;
        PlayerPoints = 0;
        pointsAtLevelStart = 0;
    }
    public void RestartLevel()
    {
        _playerPoints = pointsAtLevelStart;
        _icesMelted = 0;
        coinBagsCollected = 0;
        AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.levelStart);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        if (_icesMelted == AmountOfIces)
        {
            LevelsSolved++;
            _playerPoints += AmountOfIces * 2;
            AudioManager.Instance.PlaySoundEffect(AudioManager.Instance.levelComplete);
        }
        CurrentLevel++;
        if (CurrentLevel <= icesPerLevel.Length)
        {
            AmountOfIces = icesPerLevel[CurrentLevel - 1];
        }
        totalIceMelted += _icesMelted;
        _icesMelted = 0;

        totalCoinBagsCollected += coinBagsCollected;
        coinBagsCollected = 0;

        pointsAtLevelStart = _playerPoints;
        

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
