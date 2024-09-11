using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ObstacleBehavior : MonoBehaviour
{
    bool color_changed = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().hit_obstacle();
            turn_color("red");
        }

    }

    public Material GreenMat; // Assign the new mesh in the inspector
    public Material RedMat; // Assign the new mesh in the inspector
    public void turn_color(string color)
    {
        if (color_changed)
        {
            return;
        }
        color_changed = true;
        
        if (color == "red")
        {
            GetComponent<Renderer>().material = RedMat;
        }
        else if (color == "green")
        {
            GetComponent<Renderer>().material = GreenMat;
        }
        else 
        {
            Debug.Log("Invalid color");
        }
    }


    public float small_cube_size = 0.4f;
    public float explosion_force = 0.5f;
    public float explosion_radius = 2f;

    public void explode() {
        split_into_small_cubes();
        Destroy(gameObject);
    }

    void split_into_small_cubes() {
        for (int x = 0; x < transform.localScale.x / small_cube_size; x++)
        {
            for (int y = 0; y < transform.localScale.y / small_cube_size; y++)
            {
                for (int z = 0; z < transform.localScale.z / small_cube_size; z++)
                {
                    create_small_cube(x, y, z);
                }
            }
        }
    }

    void create_small_cube(int x, int y, int z) {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cube.transform.localScale = new Vector3(small_cube_size, small_cube_size, small_cube_size);
        Vector3 first_cube_position = transform.position - transform.localScale / 2 + cube.transform.localScale / 2;
        Vector3 unrotated_position = first_cube_position + new Vector3(x, y, z) * cube.transform.localScale.x;
        Vector3 rotated_position = transform.rotation * (unrotated_position - transform.position) + transform.position;
        cube.transform.position = rotated_position;
        cube.transform.rotation = transform.rotation;

        Rigidbody cube_rb = cube.AddComponent<Rigidbody>();
        cube_rb.mass = 0.1f;
        cube_rb.AddExplosionForce(explosion_force, transform.position, explosion_radius);

        Destroy(cube, 5f);
    }
}
