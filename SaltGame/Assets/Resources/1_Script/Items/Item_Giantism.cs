using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Giantism : BaseItem
{
    private void Update()
    {
        if(IsActiveTimeOver())
            Deactivate();
    }
    public override void Active()
    {
        SetBasicChanges();
        playerInstance.SaltKnightAsset.transform.localScale *= 2;
    }

    public override void Deactivate()
    {
        SetBasicChanges(true);
        playerInstance.SaltKnightAsset.transform.localScale /= 2;
    }
}
