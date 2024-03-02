using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.TryGetComponent(out BaseEnemy enemy))
        {
            Debug.Log("b");
            enemy.Die();
        }
    }
}
