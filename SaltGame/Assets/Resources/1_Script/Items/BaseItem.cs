using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    [SerializeField] int cost;
    [SerializeField] int attackSpeed, tirednessRecover, attackSize;
    [SerializeField] float timeActive;

    [SerializeField] bool isActive;

    public bool IsActive => isActive;

    float currentTimeActive;

    protected PlayerChanges playerChangesInstance;
    protected PlayerScrpt playerInstance;

    public void SetPlayerChanges(PlayerScrpt player, PlayerChanges playerChanges)
    {
        playerInstance = player;
        playerChangesInstance = playerChanges;
    }

    public abstract void Active();

    public abstract void Deactivate();

    public void SetBasicChanges(bool unset = false)
    {
        int setValue = 1;

        if (unset)
        {
            setValue *= -1;
            isActive = false;
        }
        else
        {
            Wallet.AddValue(-cost);
            currentTimeActive = timeActive;
            isActive = true;
        }
     

        playerChangesInstance.SetAttackSize(attackSize * setValue);
        playerChangesInstance.SetAttackSpeed(attackSpeed * setValue);
        playerChangesInstance.SetTirednessRecover(tirednessRecover * setValue);
    }

    public bool IsActiveTimeOver()
    {
        if (currentTimeActive > 0)
        {
            currentTimeActive -= Time.deltaTime;
            return false;
        }
        if (isActive)
        {
            isActive = false;
            return true;
        }
        return false;
        
    }

    public bool HaveCostValue()
    {
        return Wallet.GetCurrency() > cost && !isActive;
    }
}
