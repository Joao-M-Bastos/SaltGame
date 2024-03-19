using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    [SerializeField] HitCallback m_HitCallback;
    float cooldown;

    private void Awake()
    {
        m_HitCallback = gameObject.GetComponent<HitCallback>();
    }

    private void Update()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if(cooldown <= 0)
                Destroy(gameObject);
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BaseEnemy enemy))
        {
            //m_HitCallback.HitOtherCallback();
            enemy.KillEnemy();
        }
    }

    public void SetCooldown(float value)
    {
        cooldown = value;
    }
}
