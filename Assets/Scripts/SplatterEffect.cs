using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatterEffect : MonoBehaviour
{
    ParticleSystem splatParticle;
    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();
    private int count;
    private void Start()
    {
       // splatParticle = this.gameObject.GetComponent<ParticleSystem>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(splatParticle, other, collisionEvents);
        count = collisionEvents.Count;
        for (int i = 0; i < count; i++)
        {
            DecalPainter.Instance.Paint(collisionEvents[i].intersection, Color.white,1 , 1f);

        }
    }


}
