using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    BaseEnemy currentEnemy;

    bool isEnemy;

    private void Awake()
    {
        if (TryGetComponent(out currentEnemy)) isEnemy = true;
    }

    public void Hit()
    {
        if(isEnemy)
            currentEnemy.Die();
    }
}
