using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BaseEnemy enemy))
        {
            enemy.KillEnemy();
        }
    }
}
