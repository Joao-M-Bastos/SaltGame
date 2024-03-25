using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChanges
{
    int maxLife, maxTiredness, attackSpeed, attackSize, tirednessRecover;

    public PlayerChanges() {
        
    }

    public void SetMaxLife(int value){ maxLife += value; }
    public int GetMaxLife() { return maxLife; }


    public void SetMaxTiredness(int value) {  maxTiredness += value; }
    public int GetMaxTiredness() {return maxTiredness;}

    public void SetAttackSpeed(int value) { attackSpeed += value; }
    public int GetAttackSpeed() { return attackSpeed;}

    public void SetAttackSize(int value) { attackSize += value; }
    public int GetAttackSize() {  return attackSize;}


    public void SetTirednessRecover(int value) { tirednessRecover += value; }
    public int GetTirednessRecover() { return tirednessRecover; }
}
