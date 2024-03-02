using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryOn : MonoBehaviour
{
    [SerializeField] GameObject[] childens;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        foreach (GameObject go in childens)
            DontDestroyOnLoad(go);
    }
}
