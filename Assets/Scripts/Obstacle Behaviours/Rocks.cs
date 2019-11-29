using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    float rockSpeed = 2;
    int dir;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * rockSpeed);

    }
}
