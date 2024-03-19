using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand : MonoBehaviour
{
    [SerializeField] Transform raycastStartPoint;
    BaseSword currentSword;
    // Start is called before the first frame update
    void Start()
    {
        if (currentSword == null)
            SetSword(0);
    }

    public void SetSword(int id, string name = "")
    {
        if(id >= 0)
            currentSword = Lists.GetSwordById(id).GetComponent<BaseSword>();
        else
            currentSword = Lists.GetSwordByName(name).GetComponent<BaseSword>();

        SetNewStatus();

        Instantiate(currentSword.gameObject, this.transform);
    }

    private void SetNewStatus()
    {
        currentSword.SetSwordStatus(raycastStartPoint, 0, 0, 0);
    }

    public void TryActivateSword()
    {
        currentSword.TryActivateSword();
    }
}
