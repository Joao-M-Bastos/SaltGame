using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    HitCallback m_HitCallback;
    float timeActive;

    private void Update()
    {

        if(timeActive > 0)
        {
            timeActive -= Time.deltaTime;
            if(timeActive <= 0)
                Destroy(gameObject);
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BaseEnemy enemy))
        {
            m_HitCallback.HitEnemyCallback();
            enemy.KillEnemy();
        }
    }

    public void SetValues(HitCallback hitCallback, Vector3 trueStartPoint, int size, float _timeActice)
    {
        this.transform.position = trueStartPoint;
        transform.localScale = new Vector3(1, 2, size);
        m_HitCallback = hitCallback;
        timeActive = _timeActice;
    }
}
