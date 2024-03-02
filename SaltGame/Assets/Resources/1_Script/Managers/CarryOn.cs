using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryOn : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
