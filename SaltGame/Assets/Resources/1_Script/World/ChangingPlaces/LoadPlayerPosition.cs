using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerPosition : MonoBehaviour
{
    [SerializeField] int positionCode;
    public int Code => positionCode;

    public void SetCode(int value)
    {
        positionCode = value;
    }
}
