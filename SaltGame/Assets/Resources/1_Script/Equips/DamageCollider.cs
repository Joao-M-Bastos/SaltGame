using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    [SerializeField] HitCallback m_HitCallback;

    private void Awake()
    {
        m_HitCallback = gameObject.GetComponent<HitCallback>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BaseEnemy enemy))
        {
            //m_HitCallback.HitOtherCallback();
            enemy.KillEnemy();
        }
    }
}
