using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private GameObject bulletParent;

    private int maxHealth = 5;
    private int health;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            // We lose, if any player's health is depleted.
            Main.Singleton.GameOver();
        }
    }


    void Update()
    {
        // TODO: This is not scalable (in a project way).
        //transform.position = Input.mousePosition * 0.02f - new Vector3(5, 0, 0);

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            TakeDamage(1);
            Debug.Log("Player Health: " + health);
        }

        RaycastHit hit;
        if (Raycast(100, out hit))
        {
            //if (hit.collider.GetComponent<ActionPlane>() != null)
            {
                // Hit works.
                transform.position = hit.point;
            }
        }



        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(new Vector3(-0.2f, 0, 0));
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(new Vector3(0.2f, 0, 0));
        //}


        // Only happens one time.
        if (Input.GetMouseButtonDown(0))
            SpawnBullet(Random.ColorHSV());
	}

    void SpawnBullet(Color color)
    {
        Bullet bullet = Instantiate(bulletPrefab);
        bullet.transform.SetParent(bulletParent.transform);
        bullet.transform.position = transform.position;
        bullet.GetComponent<Renderer>().material.color = color;
    }


    private bool Raycast(int distance, out RaycastHit hit_out)
    {
        int mask = (1 << 8);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.cyan);

        if (Physics.Raycast(ray, out hit_out, distance, mask)) // True if the mouse hits ANY object with a collider.
        {
            Debug.DrawRay(hit_out.point, hit_out.normal, Color.red);
            return true;
        }

        return false;
    }
}
