using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour
{

    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent<Grow>(out var grow))
        {
            grow.ReceiveBoost();
        }
        else if(other.TryGetComponent<Enemy>(out var enemy))
        {
            enemy.ReceiveHit();
        }
    }

}
