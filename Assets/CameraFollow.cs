using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y + offset.y, player.position.z + offset.z);
    }
}
