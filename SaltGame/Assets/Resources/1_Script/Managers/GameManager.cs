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
            Application.Quit();
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void UpdadeCurrencyCanvas(int currentValue)
    {
        canvasManager.UpdadeSoulsText(currentValue);
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
