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
        GameManager.GetInstance().UpdadeCurrencyCanvas(tempCurrency, currency);
    }

    public void ResetCurrency()
    {
        tempCurrency = 0;
        GameManager.GetInstance().UpdadeCurrencyCanvas(tempCurrency, currency);
    }

    public void SaveCurrency()
    {
        currency += tempCurrency;
        tempCurrency = 0;
        GameManager.GetInstance().UpdadeCurrencyCanvas(tempCurrency, currency);
    }
    #endregion

    #region Souls

    public void AddSoulsValue(int value)
    {
        souls += value;
        GameManager.GetInstance().UpdadeSoulsCanvas(GetSouls());
    }

    public int GetSouls()
    {
        return souls;
    }

    public void ResetSouls()
    {
        souls = 0;
        GameManager.GetInstance().UpdadeSoulsCanvas(GetSouls());
    }

    #endregion
}
