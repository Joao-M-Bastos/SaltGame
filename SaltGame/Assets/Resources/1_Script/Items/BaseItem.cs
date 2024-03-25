using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    [SerializeField] int cost;
    [SerializeField] int attackSpeed, tirednessRecover, attackSize;
    [SerializeField] float timeActive;

    public abstract void Active();

    public abstract void Deactivate();

    public bool IsActiveTimeOver()
    {
        if (timeActive > 0)
        {
            timeActive -= Time.deltaTime;
            return false;
        }

        return true;
    }

    public bool HaveCostValue()
    {
        return Wallet.GetCurrency() > cost;
    }
}
