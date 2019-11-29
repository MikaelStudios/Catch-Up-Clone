using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float XclampMin = 2f;
    [SerializeField] private float XclampMax = 6f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp( player.transform.position.x, XclampMin,XclampMax), player.position.y + offset.y, player.position.z + offset.z);
    }
}
