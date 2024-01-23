using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] private Text levelTxt;
	[SerializeField] private Text icesInLevel;
	[SerializeField] private Text levelsSolved;
	[SerializeField] private Text playerPoints;

    private int totalIcesToMelt;

    private void Start()
    {
        levelTxt.text = GameManager.Instance.CurrentLevel.ToString();
        totalIcesToMelt = GameManager.Instance.AmountOfIces;
        icesInLevel.text = "0/" + totalIcesToMelt.ToString();
        levelsSolved.text = GameManager.Instance.LevelsSolved.ToString();
        playerPoints.text = GameManager.Instance.PlayerPoints.ToString();

        GameManager.Instance.pointsChanged.AddListener(UpdatePoints);
        GameManager.Instance.icesMeltedChanged.AddListener(UpdateProgress);
    }

    private void UpdatePoints(int newScore)
    {
        playerPoints.text = newScore.ToString();
    }

    private void UpdateProgress(int newProgress)
    {
        icesInLevel.text = newProgress.ToString() +"/"+ totalIcesToMelt.ToString();
    }
    
}
