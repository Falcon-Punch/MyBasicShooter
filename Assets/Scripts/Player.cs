using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private Bullet bulletPrefab;
	[SerializeField] private Enemy enemyPrefab;
	[SerializeField] private ScoreBoard board;

	private void Start()
	{
		SpawnEnemy(Random.ColorHSV());
	}

	void Update()
	{
		// TODO: This is not scalable (in a project way).
		transform.position = Input.mousePosition * 0.02f - new Vector3(5, 0, 0);

		// Only happens one time.
		if (Input.GetMouseButtonDown(0))
			SpawnBullet(Random.ColorHSV());
	}

	void SpawnBullet(Color color)
	{
		Bullet bullet = Instantiate(bulletPrefab);
		bullet.transform.position = transform.position;
		bullet.GetComponent<Renderer>().material.color = color;

		//Debug.Log("Fire bullet.");
		board.IncreaseScore(1);
	}

	public void SpawnEnemy(Color color)
	{
		Enemy enemy = Instantiate(enemyPrefab);
		enemy.transform.position = new Vector3(0, 6.0f, 0);
		enemy.GetComponent<Renderer>().material.color = color;

		Debug.Log("Enemy Spawned!!");
	}
}
