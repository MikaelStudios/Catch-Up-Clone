using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheArchMovement : MonoBehaviour
{
    float speedOfChange;
    float ChangeDirAndPosition;
    float dir;
    // Start is called before the first frame update
    void Start()
    {
        speedOfChange = Random.Range(0.5f,3f);
        ChangeDirAndPosition = Random.Range(2.16f, 8.3f);
        if (ChangeDirAndPosition < 4.66) 
        {
            dir = -1;
        }
        else 
        {
            dir = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dir == -1)
        {
            if (transform.position.x <= ChangeDirAndPosition)
            {
                transform.position = new Vector3(ChangeDirAndPosition, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position += new Vector3(dir, 0, 0) * Time.deltaTime * speedOfChange;
            }
        }
        else if (transform.position.x >= ChangeDirAndPosition) 
        {
                transform.position = new Vector3(ChangeDirAndPosition, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position += new Vector3(dir, 0, 0) * Time.deltaTime * speedOfChange;
        }
    }
}
