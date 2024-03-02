using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Wallet
{
    private static int currency;

    public static int GetCurrency()
    {
        return currency;
    }

    public static void AddValue(int value)
    {
        currency += value;
    }
}
