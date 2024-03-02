using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject PlayerPrefab;
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0) return;
    }
}
