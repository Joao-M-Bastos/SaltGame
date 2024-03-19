using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSword : BaseSword
{
    public override void HitEnemyCallback()
    {
        Debug.Log("Sword Hit enemy");
    }

    public override void SpecialEffect()
    {
        
    }
}
