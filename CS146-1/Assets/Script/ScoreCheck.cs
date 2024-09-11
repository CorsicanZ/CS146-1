using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().hit_checkpoint();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}