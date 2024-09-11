using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supply : MonoBehaviour
{
    public Material player_material;
    public Material bullet_material;
    string supply_type;
    public void change_supply_type(string type)
    {
        if (type == "health") {
            Debug.Log("spawn a health supply");
            GetComponent<MeshRenderer>().material = player_material;
        }
        else if (type == "bullet") {
            Debug.Log("spawn a bullet supply");
            GetComponent<MeshRenderer>().material = bullet_material;
        }
        else return;

        supply_type = type;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

            if (supply_type == "health")
            {
                gm.add_health();    
            }
            else if (supply_type == "bullet")
            {
                gm.add_bullet();
            }
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - 10 * Time.deltaTime);
    }
}
