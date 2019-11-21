using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float Mag;
    [SerializeField] float Roughness;
    [SerializeField] float FadeIn;
    [SerializeField] float FadeOut;
    public void Shake( )
    {
        CameraShaker.Instance.ShakeOnce(Mag, Roughness, FadeIn, FadeOut);
    }
}
