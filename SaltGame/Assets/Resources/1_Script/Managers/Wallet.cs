using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    public static Wallet instance;

    private int currency;
    private int tempCurrency;

    private int souls;

    public void Awake()
    {
        currency = 0;

        if(instance == null)
            instance = this;
    }

    public static Wallet GetWallet()
    {
        return instance;
    }

    public void ResetWallet()
    {
        currency = 0;
        tempCurrency = 0;
        souls = 0;
    }

    #region Currency

    public int GetCurrency()
    {
        return currency + tempCurrency;
    }

    public int GetTempCurrency()
    {
        return tempCurrency;
    }

    public void AddCurrencyValue(int value)
    {
        tempCurrency += value;
        CanvasManager.GetInstance().UpdateCurrencyText(tempCurrency, currency);
    }

    public void ResetCurrency()
    {
        tempCurrency = 0;
        CanvasManager.GetInstance().UpdateCurrencyText(tempCurrency, currency);
    }

    public void SaveCurrency()
    {
        currency += tempCurrency;
        tempCurrency = 0;
        CanvasManager.GetInstance().UpdateCurrencyText(tempCurrency, currency);
    }

    #endregion

    #region Souls

    public void AddSoulsValue(int value)
    {
        souls += value;
        CanvasManager.GetInstance().UpdadeSoulsText(GetSouls());
    }

    public int GetSouls()
    {
        return souls;
    }

    public void ResetSouls()
    {
        souls = 0;
        CanvasManager.GetInstance().UpdadeSoulsText(GetSouls());
    }

    #endregion
}
