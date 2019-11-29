using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheLongCube : MonoBehaviour
{
    float left = 2.6f;
    float right = 3.73f;
    float rand;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            transform.position = new Vector3(left, transform.position.y, transform.position.z);
        }
        else 
        {
            transform.position = new Vector3(right, transform.position.y, transform.position.z);
        }
    }
}
