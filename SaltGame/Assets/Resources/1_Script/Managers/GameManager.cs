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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(canvasManager.CurrentCanvasState == CanvasStates.InGame)
            {
                canvasManager.ChangeCanvas(CanvasStates.PauseMenu);
            }
            else
            {
                canvasManager.ChangeCanvas(CanvasStates.InGame);
            }
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void UpdadeSoulsCanvas(int currentValue)
    {
        canvasManager.UpdadeSoulsText(currentValue);
    }

    public void UpdadeCurrencyCanvas(int currentValue, int tempValue)
    {
        canvasManager.UpdateCurrencyText(currentValue, tempValue);
    }

    public void UpdateLife(int lifeValue)
    {
        canvasManager.UpdadeLifeText(lifeValue);
        if (lifeValue <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Wallet.instance.ResetSouls();
        Wallet.instance.ResetCurrency();
        CommomMetods.GoToScene(1);
    }
}
