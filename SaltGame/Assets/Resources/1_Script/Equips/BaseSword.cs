using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseSword : MonoBehaviour, HitCallback
{
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] float baseAttackDelay, attackDelayReductionPercentage = 100;
    [SerializeField] int baseTiredness, baseSize;
    [SerializeField] GameObject boxCollider;
    float currentAttackDelay;
    int tiredness;
    Transform boxStartPoint;

    GameObject collision;

    public delegate void HitCallback();
    public static event HitCallback onPlayerHit;

    public void SetSwordStatus(Transform _boxStartPoint)
    {
        boxStartPoint = _boxStartPoint;
    }

    public void ActivateSword(int deltaSize)
    {
        int currentSize = baseSize + deltaSize;

        Vector3 trueStartPoint = boxStartPoint.transform.position + boxStartPoint.transform.forward * (currentSize / 2);

        GameObject currentBox = Instantiate(boxCollider, boxStartPoint.transform);
        currentBox.GetComponent<DamageCollider>().SetValues(this ,trueStartPoint, currentSize, 0.2f);

        currentAttackDelay = baseAttackDelay;
    }

    public int GetTiredness()
    {
        return tiredness;
    }

    public bool IsInCooldown(float deltaReduction)
    {
        if (currentAttackDelay > 0)
        {
            currentAttackDelay -= Time.deltaTime * ((attackDelayReductionPercentage + deltaReduction) / 100);
            return true;
        }
        return false;
    }

    public abstract void SpecialEffect();

    public abstract void HitEnemyCallback();
}
