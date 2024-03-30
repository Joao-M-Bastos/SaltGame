using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Giantism : BaseItem
{
    public override void ItemUpdate()
    {
        if(IsActiveTimeOver())
            Deactivate();
    }
    public override void Active()
    {
        Debug.Log("a");
        SetBasicChanges();
        playerInstance.SaltKnightAsset.transform.localScale = new Vector3(2,2,2);
        playerInstance.SaltKnightAsset.transform.localPosition = new Vector3(0, 1, 0);
    }

    public override void Deactivate()
    {
        Debug.Log("b");
        UnSetBasicChanges();
        playerInstance.SaltKnightAsset.transform.localScale = new Vector3(1,1,1);
        playerInstance.SaltKnightAsset.transform.localPosition = new Vector3(0, 0, 0);
    }
}
