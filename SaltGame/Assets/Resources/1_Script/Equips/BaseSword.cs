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
    float cooldownReductionPercentage = 100, currentCooldown;
    int tiredness, size;
    float currentSize;
    Transform raycastStartPoint;

    public delegate void HitCallback();
    public static event HitCallback onPlayerHit;

    public void SetSwordStatus(Transform _raycastStartPoint, int _tiredness, int _size)
    {
        raycastStartPoint = _raycastStartPoint;
        tiredness = baseTiredness + _tiredness;
        size = baseSize + _size;
    }

    public void TryActivateSword()
    {
        if(currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime * (cooldownReductionPercentage / 100);
            return;
        }

        currentSize = size;

        GenerateRay(raycastStartPoint.position);

        currentCooldown = baseCooldown;
    }

    private void GenerateRay(Vector3 startingPosition)
    {
        Debug.DrawRay(startingPosition, raycastStartPoint.forward * size, Color.red, 2);
        if (Physics.Raycast(raycastStartPoint.position, raycastStartPoint.forward, out RaycastHit hit, currentSize, enemyLayerMask))
        {
            //Physics.SphereCastAll
            //onPlayerHit?.Invoke();
            HitOtherCallback();
            hit.collider.gameObject.GetComponent<BaseEnemy>().KillEnemy();

            
            

            //if(distance <= size)
                //GenerateRay(startingPosition + (raycastStartPoint.forward * distance * 1.1f));
        }
    }

    public int GetTiredness()
    {
        return tiredness;
    }

    public abstract void SpecialEffect();

    public abstract void HitOtherCallback();

}
