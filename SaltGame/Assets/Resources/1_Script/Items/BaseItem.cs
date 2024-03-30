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

    public abstract void ItemUpdate();

    public void SetBasicChanges(bool unset = false)
    {
        Wallet.AddValue(-cost);
        currentTimeActive = timeActive;
        isActive = true;

        playerChangesInstance.SetAttackSize(attackSize);
        playerChangesInstance.SetAttackSpeed(attackSpeed);
        playerChangesInstance.SetTirednessRecover(tirednessRecover);
    }

    public void UnSetBasicChanges()
    {
        isActive = false;

        playerChangesInstance.SetAttackSize(-attackSize);
        playerChangesInstance.SetAttackSpeed(-attackSpeed);
        playerChangesInstance.SetTirednessRecover(-tirednessRecover);
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
        return Wallet.GetCurrency() > cost;
    }
}
