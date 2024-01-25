using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScenes : MonoBehaviour
{
	public bool isFinal;
	public string levelName = "lvl 1";

    [SerializeField] Text levelsSolved;
    [SerializeField] Text coinBags;
    [SerializeField] Text iceMelted;
    [SerializeField] Text points;

    private void Start()
    {
        if (isFinal)
        {
            levelsSolved.text = GameManager.Instance.LevelsSolved.ToString();
            coinBags.text = GameManager.Instance.totalCoinBagsCollected.ToString();
            iceMelted.text = GameManager.Instance.totalIceMelted.ToString();
            points.text = GameManager.Instance.PlayerPoints.ToString();
        }
    }
    public void LoadLevel()
	{
		SceneManager.LoadScene(levelName);
	}

    public void FinishGame()
    {
        Application.Quit();
    }
}
