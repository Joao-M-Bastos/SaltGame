using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wave : MonoBehaviour
{
    [SerializeField] GameObject[] potencialEnemies;
    
    public void StartWave()
    {
        Debug.Log("Wave Started");
    }
}
