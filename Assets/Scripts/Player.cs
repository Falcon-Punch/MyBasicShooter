using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] private Bullet bulletPrefab;

	void Update()
	{
		// TODO: This is not scalable (in a project way).
		// Mouse Support
		transform.position = Input.mousePosition * 0.02f - new Vector3(5, 0, 0);

		RaycastHit hit;

		if (Raycast(100, out hit))
		{
			// Hit works.
			transform.position = hit.point;
		}

		// Hit maybe?


		//if(Input.GetKey(KeyCode.A))
		//{
		//	transform.Translate(new Vector3(-0.2f, 0, 0));
		//}
		//if (Input.GetKey(KeyCode.D))
		//{
		//	transform.Translate(new Vector3(0.2f, 0, 0));
		//}


		// Only happens one time.
		if (Input.GetMouseButtonDown(0))
			SpawnBullet(Random.ColorHSV());
	}

	void SpawnBullet(Color color)
	{
		Bullet bullet = Instantiate(bulletPrefab);
		bullet.transform.position = transform.position;
		bullet.GetComponent<Renderer>().material.color = color;
	}

	//public void SpawnEnemy(Color color)
	//{
	//	Enemy enemy = Instantiate(enemyPrefab);
	//	enemy.transform.position = new Vector3(0, 6.0f, 0);
	//	enemy.GetComponent<Renderer>().material.color = color;

	//	Debug.Log("Enemy Spawned!!");
	//}

	private bool Raycast(int distance, out RaycastHit hit_out)
	{
		//RaycastHit hit = new RaycastHit();
		//int mask = (1 << 8);

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * distance, Color.cyan);

		// removed mask as 4th var
		if (Physics.Raycast(ray, out hit_out, distance))
		{
			Debug.DrawRay(hit_out.point, hit_out.normal, Color.red);
			return true;
		}

		return false;
	}
}
