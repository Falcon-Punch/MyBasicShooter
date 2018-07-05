using UnityEngine;

public class Enemy : MonoBehaviour
{
	private int health;
	private int pointValue;
	private Vector3 moveDirection = new Vector3(0.05f, 0, 0);
	[SerializeField] private ScoreBoard scoreBoard;

	public int Score
	{
		get { return pointValue; }
	}


	// Use this for initialization
	void Start ()
	{
		health = 3;
		pointValue = 12;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Move();

		if (health <= 0)
		{
			Die();
		}
	}

	private void Move()
	{
		transform.position += moveDirection;

		if (transform.position.x > 6 || transform.position.x < -6)
		{
			moveDirection.x = -moveDirection.x;
		}
	}

	private void Shoot()
	{

	}

	private void Die()
	{
		scoreBoard.IncreaseScore(pointValue);
		Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider other)
	{
		health--;
		Debug.Log("Triggered");
	}

}
