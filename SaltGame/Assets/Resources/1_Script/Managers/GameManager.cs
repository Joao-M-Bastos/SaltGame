using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    bool loadedInScene;
    [SerializeField]int numOfWavesDestroyed;

    public int NumOfWavesDestroyed => numOfWavesDestroyed;

    public static GameManager GetInstance()
    {        
        return instance;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void GameOver()
    {
        Wallet.instance.ResetSouls();
        Wallet.instance.ResetCurrency();
        CommomMetods.GoToScene(1);
    }

    public bool IsLoadedInScene()
    {
        return loadedInScene;
    }

    public void SetLoadedInScene(bool value)
    {
        loadedInScene = value;
    }

    public void AddDestroyedWave(int value)
    {
        numOfWavesDestroyed += value;
    }

    public bool ReduceDestroyedWave()
    {
        bool temp = false;

        if (numOfWavesDestroyed > 0)
        {
            temp = true;
            numOfWavesDestroyed--;
        }
        return temp;
    }

    public void ResetDestroyedWaveNum()
    {
        numOfWavesDestroyed = 0;
    }
}
