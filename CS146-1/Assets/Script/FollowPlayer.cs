using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    public Transform player_transform;
    public Vector3 camera_offset;
    
    // Update is called once per frame
    void Update()
    {
        transform.position = player_transform.position + camera_offset;
    }
}
