using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSimple : Wave
{
    public override void GenerateRound()
    {
        //GameObject enemy, int amount, float inteval, float cooldown

        currentRoundNumber++;

        switch (currentRoundNumber)
        {
            case 1:
                spawnBehaviour.GerarRound(potencialEnemies[0], 6, 0f, 0);
                break;
        }
    }
}
