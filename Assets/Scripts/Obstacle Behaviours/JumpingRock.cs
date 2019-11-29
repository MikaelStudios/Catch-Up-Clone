using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class JumpingRock : MonoBehaviour
{
    [SerializeField] bool IsIndependent = true;
    [SerializeField] private float Max;
    [SerializeField] private float Min;
    bool Now = false;
    private void Start()
    {
        if (IsIndependent == true)
        {
            transform.position = new Vector3(Random.Range(Max, Min), transform.position.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Now == true) 
        {
            transform.Rotate(new Vector3(-1, 0, 0) * Time.deltaTime * 100);
            if (IsIndependent == true) 
            {
                transform.position += new Vector3((int)Random.Range(-1,1), 0, -1) * Time.deltaTime * Random.Range(5, 9);
            }
            else
            {
                transform.position += new Vector3(0, 0, -1) * Time.deltaTime * Random.Range(9, 15);
            }
        }
        //transform.localPosition += new Vector3(randBOunceDir, 0, 0) * 0.1f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Now = true;
        CameraShaker.Instance.ShakeOnce(0.7f, 5, .1f, 3.5f);
    }
}
