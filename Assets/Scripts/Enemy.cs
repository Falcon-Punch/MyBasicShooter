using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] HomingMissle misslePrefab;
    
    private int health;
    private int pointValue;
    private Vector3 speed = new Vector3(1, 0f, 0); // Units per second the right.
    //private float xSpeed;
    //[SerializeField] private ScoreBoard scoreBoard;

    public int Score
    {
        get { return pointValue; }
    }

	// Use this for initialization
	void Start()
    {
        health = 3;
        pointValue = 5;

        Invoke("Shoot", 1.5f);
	}
	
	// Update is called once per frame
	void Update()
    {
        Move();

        if (health <= 0)
            Die();
    }

    private void Move()
    {
        // Move.
        transform.position += speed * Time.deltaTime;

        // Bounds detection.
        if (transform.position.x > 6 || transform.position.x < -6)
        {
            speed.x = -speed.x;
        }
    }

    private void Shoot()
    {
        HomingMissle missle = Instantiate(misslePrefab);
        missle.transform.SetParent(Main.Singleton.bulletParent.transform);
        missle.transform.position = transform.position;
    }

    private void Die()
    {
        Main.Singleton.IncreaseScore(pointValue);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        health--;
        Debug.Log("Tiggered!");
    }
}