using UnityEngine;

public class Bullet : MonoBehaviour
{
	private void Update()
	{
		transform.Translate(new Vector3(0, 0.5f, 0));

		if (transform.position.y > 10)
		{
			Die();
		}

	}

	private void Die()
	{
		Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.GetComponent<Enemy>() != null)
		{
			Die();
		}
	}
}
