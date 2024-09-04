using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody player_rigidbody;
    public Transform player_transform;
    public float side_force = 500f;

    public float jump_force = 20000f;
    public float jump_time = 0.5f;
    private bool on_ground = false;
    private bool jumping = false;
    private float last_time_on_ground = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PlayerController initiated");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player on ground");
            on_ground = true;
            last_time_on_ground = 0;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Player leaves ground");
            on_ground = false;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && on_ground == true)
        {
            jumping = true;
        }

        if(transform.position.y < -1.5)
        {
            FindObjectOfType<GameManager>().game_over();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("a"))
        {
            player_rigidbody.AddForce(-side_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        else if (Input.GetKey("d"))
        {
            player_rigidbody.AddForce(side_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (jumping == true)
        {
            player_rigidbody.AddForce(0, jump_force * Time.deltaTime, 0, ForceMode.VelocityChange);

            last_time_on_ground += Time.deltaTime;
            if (last_time_on_ground > jump_time)
            {
                jumping = false;
            }
        }
    }
}
