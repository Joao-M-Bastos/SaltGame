using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Wave : MonoBehaviour
{
    [SerializeField] protected GameObject[] potencialEnemies;
    [SerializeField] int quantityOfRounds;
    [SerializeField] int currencyValue;

    protected int currentRoundNumber;

    protected SpawnBehaviour spawnBehaviour;

    private PlayerMachineController playerMachineController;

    //Tirar isso depois da apresentação

    bool hasStarted;
        
    private void Awake()
    {
        currentRoundNumber = 0;
        playerMachineController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMachineController>();
        spawnBehaviour = GetComponent<SpawnBehaviour>();
        
        GenerateRound();
    }

    private void Update()
    {
        //Esses ifs pertence á maneira temporaria de solucionar o problema de save
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0 && !hasStarted)
            hasStarted = true;

        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && hasStarted)
            HandleEndRound(true);

        /* Esse codigo é o normal/correto mas não funciona no sistema de save simples
        if (spawnBehaviour.amountToSpawn <= 0 && NumOfEnemiesAlive.getNumOfEnemiesAlive() <= 0)
        {
            if (currentRoundNumber >= quantityOfRounds)
                HandleEndRound(true);
            else
                HandleEndRound(false);
        }*/
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
        Wallet.instance.AddCurrencyValue(currencyValue);

        //Para o metodo novo de salvamento
        //GameManager.GetInstance().AddDestroyedWave(1);

        playerMachineController.ChangeState(playerMachineController.movingState);
        Destroy(this.gameObject);
    }

    public void OnPlayClick()
    {
        GenerateRound();
    }

    public abstract void GenerateRound();
}
