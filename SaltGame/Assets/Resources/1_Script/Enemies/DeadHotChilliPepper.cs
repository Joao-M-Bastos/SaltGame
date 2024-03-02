using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadHotChilliPepper : BaseEnemy
{
    public override void SpecialMove()
    {
        throw new System.NotImplementedException();
    }

    private void FixedUpdate()
    {
        MoveFoward();
    }
}
