using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseSword : MonoBehaviour
{
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] float baseCooldown;
    [SerializeField] int baseTiredness, baseSize;
    [SerializeField] GameObject boxCollider;
    float cooldownReductionPercentage = 100, currentCooldown;
    int tiredness, size;
    float currentSize;
    Transform boxStartPoint;

    GameObject collision;

    public delegate void HitCallback();
    public static event HitCallback onPlayerHit;

    public void SetSwordStatus(Transform _raycastStartPoint, int _tiredness, int _size)
    {
        boxStartPoint = _raycastStartPoint;
        tiredness = baseTiredness + _tiredness;
        size = baseSize + _size;
    }

    public void TryActivateSword()
    {
        if(currentCooldown > 0)
        {
          //return;
        }

        currentSize = size;

        Vector3 trueStartPoint = boxStartPoint.transform.position + boxStartPoint.transform.forward * (size/ 2);

        GameObject currentBox = Instantiate(boxCollider, boxStartPoint.transform);
        currentBox.transform.position = trueStartPoint;
        currentBox.GetComponent<DamageCollider>().SetCooldown(2f);
        // currentCooldown = baseCooldown;
    }

    private void GenerateRay(Vector3 startingPosition)
    {
        
    }

    public int GetTiredness()
    {
        return tiredness;
    }

    public abstract void SpecialEffect();

    public abstract void HitOtherCallback();

}
