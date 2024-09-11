using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private AudioSource explosion;
    // Start is called before the first frame update
    public Rigidbody bullet_rigidbody;
    public float bullet_speed = 5f;
    public int bullet_life = 2;
    // Update is called once per frame
    void FixedUpdate()
    {
        bullet_rigidbody.velocity = new Vector3(0, 0, bullet_speed);
        if (bullet_rigidbody.position.z > 50)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            collision.gameObject.GetComponent<ObstacleBehavior>().explode();

            bullet_life -= 1;
            explosion.Play();
            if (bullet_life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
