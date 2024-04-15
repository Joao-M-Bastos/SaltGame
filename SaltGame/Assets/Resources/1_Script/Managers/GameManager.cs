using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    [SerializeField] CanvasManager canvasManager;

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
}
