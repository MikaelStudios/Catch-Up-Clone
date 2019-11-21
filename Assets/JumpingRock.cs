using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingRock : MonoBehaviour
{
    float randBOunceDir;
    private void Start()
    {
        randBOunceDir = Random.Range(-1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition += new Vector3(randBOunceDir, 0, 0) * 0.1f;
    }
}
