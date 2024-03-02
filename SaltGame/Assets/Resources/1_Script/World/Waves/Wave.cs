using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wave : MonoBehaviour
{
    [SerializeField] protected GameObject[] potencialEnemies;
    [SerializeField] int quantityOfRounds;

    protected int currentRoundNumber;

    protected SpawnBehaviour spawnBehaviour;

    private PlayerMachineController playerMachineController;

    private void Awake()
    {
        currentRoundNumber = 0;
        playerMachineController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMachineController>();
        spawnBehaviour = GetComponent<SpawnBehaviour>();
        GenerateRound();
    }

    private void Update()
    {
        Debug.Log( NumOfEnemiesAlive.getNumOfEnemiesAlive());
        Debug.Log("Amount" + spawnBehaviour.amountToSpawn);
        if (spawnBehaviour.amountToSpawn <= 0 && NumOfEnemiesAlive.getNumOfEnemiesAlive() <= 0)
        {
            if (currentRoundNumber >= quantityOfRounds)
                HandleEndRound(true);
            else
                HandleEndRound(false);
        }
    }

    public void HandleEndRound(bool lastRound)
    {
        if (lastRound)
            FinishWave();
        else
            GenerateRound();
    }

    private void FinishWave()
    {
        playerMachineController.ChangeState(playerMachineController.movingState);
        Destroy(this.gameObject);
    }

    public void OnPlayClick()
    {
        GenerateRound();
    }

    public abstract void GenerateRound();
}
