using UnityEngine;

public class FloorScript : MonoBehaviour
{
    Transform Player;
    private readonly float PlayerDistance = 21.3f; // The Distance for the player to reach for it to move to next point
    [SerializeField] private float DistanceT0Change = 31;
    [SerializeField] private int NumberOfFloors = 3;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (Player.position.z >= transform.position.z + PlayerDistance && Player.position.z <= transform.position.z + DistanceT0Change)
        {
         //   Debug.Log("Became Invisible");
            transform.position += new Vector3(0, 0, DistanceT0Change * NumberOfFloors);
        }
    }
}
