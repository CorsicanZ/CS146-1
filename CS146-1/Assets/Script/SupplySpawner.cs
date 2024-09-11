using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplySpawner : MonoBehaviour
{
    public GameObject supply_prefab;
    public float supply_spawn_ineraval = 2f;
    public float supply_spawn_prob = 0.5f;
    public float supply_spawn_z = 90f;
    float spawn_time = 0;

    // Update is called once per frame
    void Update()
    {
        spawn_time += Time.deltaTime;
        if (spawn_time > supply_spawn_ineraval)
        {
            spawn_time = 0;
            if (Random.value < supply_spawn_prob)
            {
                GameObject sp = Instantiate(supply_prefab, new Vector3(Random.Range(-5f, 5f), 3f, supply_spawn_z), Quaternion.identity);
                float v = Random.value;
                Debug.Log(v);
                if(v < 0.5f) {
                    sp.GetComponent<Supply>().change_supply_type("health");
                }
                else {
                    sp.GetComponent<Supply>().change_supply_type("bullet");
                }
            }
        }
    }
}
