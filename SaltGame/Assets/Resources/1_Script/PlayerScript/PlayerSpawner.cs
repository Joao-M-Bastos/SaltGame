using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0) return;
        
        GameObject player = Instantiate(PlayerPrefab, this.transform.position, PlayerPrefab.transform.rotation);
        virtualCamera.Follow = player.transform;
        
    }
}
