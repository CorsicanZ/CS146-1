using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject long_obstacle;
    public GameObject short_obstacle;

    public float spawn_distance = 90f;
    private float spawn_time = 0;
    public float spawn_interval = 3f;

    // Update is called once per frame
    void Update()
    {
        spawn_time += Time.deltaTime;
        if (spawn_time > spawn_interval)
        {
            // Debug.Log(spawn_time);
            // Use second decimal digit of spawn time to randomly decide whether generate a bunch of small obstacles or a huge obstacle
            if ((int)((spawn_time * 10000) % 10) % 2 == 0)
            {
                generate_bunch_obstacles();
            }
            else
            {
                generate_huge_obstacle();
            }

            spawn_time -= spawn_interval;
        }
    }

    void generate_bunch_obstacles()
    {
        float x = Random.Range(-1.5f, 1.5f);
        Instantiate(short_obstacle, new Vector3(x, 1, spawn_distance), Quaternion.identity);
    }

    void generate_huge_obstacle()
    {
        Instantiate(long_obstacle, new Vector3(Random.Range(-2.5f, 2.5f), 1, spawn_distance), Quaternion.identity);
    }
}
