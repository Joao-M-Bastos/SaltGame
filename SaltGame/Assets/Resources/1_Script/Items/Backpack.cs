using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField] Transform hightThrowPoint, lowThrowPoint;
    BaseItem currentSlotOne, currentSlotTwo;

    void Start()
    {
        if (currentSlotOne == null)
            SetItem(0, 0);

        if (currentSlotTwo == null)
            SetItem(1, 0);
    }

    public void SetItem(int slot,int id, string name = "")
    {
        BaseItem item = null;

        if (id >= 0)
            item = Lists.GetSwordById(id).GetComponent<BaseSword>();
        else
            item = Lists.GetSwordByName(name).GetComponent<BaseSword>();

        Instantiate(currentSword.gameObject, this.transform);
    }
}
