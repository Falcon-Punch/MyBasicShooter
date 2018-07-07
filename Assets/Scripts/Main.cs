using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	public static Main Singleton = null;
	[SerializeField] ScoreBoard scoreBoard;
	[SerializeField] Enemy enemyPrefab;

	private List<Enemy> enemies = new List<Enemy>();

	private void Start()
	{
		InvokeRepeating("SpawnEnemy", 1, 3);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SpawnEnemy();
		}
	}

	private void SpawnEnemy()
	{
		Enemy enemy = Instantiate(enemyPrefab);
		enemy.GetComponent<MeshRenderer>().material.SetColor("_Color", Random.ColorHSV());
	}

	public void IncreaseScore(int amount)
	{
		scoreBoard.IncreaseScore(amount);
	}


	private void Awake()
	{
		if (Singleton == null)
		{
			Singleton = this;
		}
		else if (Singleton != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	public void ProveIt()
	{
		Debug.Log("It Works!!");
	}

}
