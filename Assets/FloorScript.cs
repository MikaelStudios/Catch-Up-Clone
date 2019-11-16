using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    Transform Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (Player.position.z >= transform.position.z + 29 && Player.position.z <= transform.position.z + 31)
        {
         //   Debug.Log("Became Invisible");
            transform.position += new Vector3(0, 0, 31 * 2);
        }
    }
}
