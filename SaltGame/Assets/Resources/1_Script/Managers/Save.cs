using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public int soulsNum;
    public int currencyNum;
    public int tempCurrencyNum;

    public float playerPosition;
    public int playerScene;
    public int playerState;

    public int playerEnergy;
    public int playerLife;

    public int numOfWavesDestroyed;

    public List<float> enemyPosition = new List<float>();
    public List<int> enemyDirection = new List<int>();
}
