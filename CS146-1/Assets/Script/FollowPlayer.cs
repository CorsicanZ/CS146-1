using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    public Transform player_transform;
    public Vector3 camera_offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player_transform.position + camera_offset;
    }
}
