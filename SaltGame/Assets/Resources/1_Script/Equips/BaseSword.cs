using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BaseSword : MonoBehaviour
{
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] int baseTiredness, baseSize;
    int tiredness, size;
    Transform raycastStartPoint;
    float cooldown;

    public delegate void HitCallback();
    public static event HitCallback onPlayerHit;

    public void SetSwordStatus(Transform _raycastStartPoint, int _tiredness, int _size)
    {
        raycastStartPoint = _raycastStartPoint;
        tiredness = baseTiredness + _tiredness;
        size = baseSize + _size;
    }

    public void ActivateSword()
    {
        Debug.DrawRay(raycastStartPoint.position, raycastStartPoint.forward * size, Color.red, 2);
        if (Physics.Raycast(raycastStartPoint.position, raycastStartPoint.forward, out RaycastHit hit, size, enemyLayerMask) ||
            Physics.Raycast(raycastStartPoint.position - (Vector3.down / 2), raycastStartPoint.forward, out RaycastHit hitb, size, enemyLayerMask)) {

            onPlayerHit?.Invoke();
            HitOtherCallback();
            hit.collider.gameObject.GetComponent<BaseEnemy>().KillEnemy();
            ActivateSword();
        }
    }

    public int GetTiredness()
    {
        return tiredness;
    }

    public abstract void SpecialEffect();

    public abstract void HitOtherCallback();

}
