using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float JumpForce;
    public bool IsStairs;
    float position;
    private void Start()
    {
        if (IsStairs == false)
        {
            position = Random.Range(0.3f, 6.3f);
            transform.position = new Vector3(position, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            other.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0)*JumpForce *50 );
        }
    }
}
