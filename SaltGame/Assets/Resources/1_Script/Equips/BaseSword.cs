using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSword : MonoBehaviour
{
    [SerializeField] Transform raycastStartPoint;
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] int tiredness, size;
    float cooldown;

    public void ActivateSwordCollider()
    {
        Debug.DrawRay(raycastStartPoint.position, raycastStartPoint.forward, Color.red ,size);
        if(Physics.Raycast(raycastStartPoint.position, raycastStartPoint.forward,out RaycastHit hit ,size, enemyLayerMask)){
            HitOtherCallback();    
            hit.collider.gameObject.GetComponent<BaseEnemy>().KillEnemy();
        }
        else if (Physics.Raycast(raycastStartPoint.position - (Vector3.down/2), raycastStartPoint.forward, out RaycastHit hitb, size, enemyLayerMask))
        {
            HitOtherCallback();
            hit.collider.gameObject.GetComponent<BaseEnemy>().KillEnemy();
        }
    }

    public int GetTiredness()
    {
        return tiredness;
    }

    public abstract void SpecialEffect();

    public abstract void HitOtherCallback();

}
