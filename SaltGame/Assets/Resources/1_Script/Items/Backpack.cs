using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Backpack : MonoBehaviour
{
    [SerializeField] Transform hightThrowPoint, lowThrowPoint;
    BaseItem[] currentSlots;
    PlayerChanges playerChangesInstances;
    PlayerScrpt playerInstance;

    void Start()
    {
        currentSlots = new BaseItem[2];

        SetItem(0, 0);
        SetItem(1, 1);
    }

    private void Update()
    {
        if (currentSlots != null) {
            foreach(BaseItem item in currentSlots)
            {
                item.ItemUpdate();
            }
        }
    }
    public void SetPlayer(PlayerScrpt player, PlayerChanges playerChanges)
    {
        playerInstance = player;
        playerChangesInstances = playerChanges;
    }

    public void SetItem(int slot,int id, string name = "")
    {
        BaseItem item;

        if (id >= 0)
            item = Lists.GetItemById(id).GetComponent<BaseItem>();
        else
            item = Lists.GetItemByName(name).GetComponent<BaseItem>();

        currentSlots[slot] = item;
        currentSlots[slot].SetPlayerChanges(playerInstance, playerChangesInstances);
    }

    public void UseItem(int slot)
    {
        if (currentSlots[slot].IsActive)
        {
            Debug.Log("Is already active");
            return;
        }

        if (currentSlots[slot].HaveCostValue())
        {
            currentSlots[slot].Active();
        }
        else
        {
            Debug.Log("NotEnouthSouls");
        }
    }

    public void DeactivateItems()
    {
        foreach (BaseItem item in currentSlots)
        {
            if(item.IsActive)
                item.Deactivate();
        }
    }

}
