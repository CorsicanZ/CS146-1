using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(FindObjectOfType<GameManager>().is_game_ended) return;

            Transform obstacle = transform.parent;
            obstacle.GetComponent<ObstacleBehavior>().turn_color("green");
        }
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
