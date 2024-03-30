using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChanges
{
    int maxLife, maxEnergy, attackSpeed, attackSize, energyRecover;

    public PlayerChanges() {
        
    }

    public void SetMaxLife(int value){ maxLife += value; }
    public int GetMaxLife() { return maxLife; }


    public void SetMaxEnergy(int value) { maxEnergy += value; }
    public int GetMaxEnergy() {return maxEnergy; }

    public void SetAttackSpeed(int value) { attackSpeed += value; }
    public int GetAttackSpeed() { return attackSpeed;}

    public void SetAttackSize(int value) { attackSize += value; }
    public int GetAttackSize() {  return attackSize;}


    public void SetEnergyRecover(int value) { energyRecover += value; }
    public int GetEnergyRecover() { return energyRecover; }
}
