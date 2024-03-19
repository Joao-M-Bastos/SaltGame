using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseSword : MonoBehaviour, HitCallback
{
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] float baseCooldown, baseAttackDelay;
    [SerializeField] int baseTiredness, baseSize;
    [SerializeField] GameObject boxCollider;
    float cooldownReductionPercentage = 100, currentCooldown, attackDelay;
    int tiredness, size;
    float currentSize;
    Transform boxStartPoint;

    GameObject collision;

    public delegate void HitCallback();
    public static event HitCallback onPlayerHit;

    public void SetSwordStatus(Transform _boxStartPoint, int _tiredness, int _size, float _attackDelay)
    {
        boxStartPoint = _boxStartPoint;
        tiredness = baseTiredness + _tiredness;
        size = baseSize + _size;
        attackDelay = baseAttackDelay + _attackDelay;
    }

    public void TryActivateSword()
    {
        if(currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime * (cooldownReductionPercentage/100);
            return;
        }

        currentSize = size;

        Vector3 trueStartPoint = boxStartPoint.transform.position + boxStartPoint.transform.forward * (size/ 2);

        GameObject currentBox = Instantiate(boxCollider, boxStartPoint.transform);

        currentBox.GetComponent<DamageCollider>().SetValues(this ,trueStartPoint, size, attackDelay,0.2f);

        currentCooldown = baseCooldown;
    }

    public int GetTiredness()
    {
        return tiredness;
    }

    public abstract void SpecialEffect();

    public abstract void HitEnemyCallback();
}
