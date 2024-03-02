using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShildCollider : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BaseProjectile>(out BaseProjectile projectile))
            Destroy(other);
    }
}
