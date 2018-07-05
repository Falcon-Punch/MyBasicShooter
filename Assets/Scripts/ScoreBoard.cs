using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
	[SerializeField] private Image winScreen;
  private int score = 0;

	private void Start()
	{
		GetComponentInChildren<Text>().text = "0";
	}

	public void IncreaseScore(int pointValue)
  {
    score += pointValue;
    GetComponentInChildren<Text>().text = score.ToString();

		if (score >= 100)
		{
			winScreen.gameObject.SetActive(true);
		}
	}
}
