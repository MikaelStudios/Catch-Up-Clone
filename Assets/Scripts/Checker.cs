using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScorePoint"))
        {
            ScoreManager.ScoreInstance.ScoreUpdate();
        }
    }

}
