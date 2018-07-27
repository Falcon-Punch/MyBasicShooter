using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 speed = new Vector3(0, 3, 0);

    private void Update()
    {
        //transform.position += new Vector3(0, 0.5f, 0);
        transform.Translate(speed * Time.deltaTime);

        if (transform.position.y > 10)
            Die();
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