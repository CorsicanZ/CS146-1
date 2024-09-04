using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public Rigidbody obstacle_rigidbody;
    public float obstacle_speed = 10;

    // Update is called once per frame
    void FixedUpdate()
    {
        obstacle_rigidbody.velocity = new Vector3(0, 0, -obstacle_speed);

        if(obstacle_rigidbody.position.z < -5)
        {
            Destroy(gameObject); 
        }
    }
}
