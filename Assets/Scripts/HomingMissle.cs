using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissle : MonoBehaviour
{
    private float lifespan = 4; // Seconds.
    private float speed = 2; // Units per Second.

	void Update()
    {
        Move();

        lifespan -= Time.deltaTime;
        if (lifespan < 0)
            Die();
	}

    private void Move()
    {
        //transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        transform.position = Vector3.MoveTowards(transform.position,
            Main.Singleton.player.transform.position,
            speed * Time.deltaTime);

        transform.LookAt(Main.Singleton.player.transform.position);

        if (Vector3.Distance(transform.position, Main.Singleton.player.transform.position) < 0.5f)
        {
            // Take a hit.
            Main.Singleton.player.TakeDamage(1);
            Die();
        }

    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
