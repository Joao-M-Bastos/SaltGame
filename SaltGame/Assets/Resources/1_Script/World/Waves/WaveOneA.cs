using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveOneA : Wave
{
    public override void GenerateRound()
    {
        //GameObject enemy, int amount, float inteval, float cooldown

        currentRoundNumber++;

        switch (currentRoundNumber)
        {
            case 1:
                spawnBehaviour.GerarRound(potencialEnemies[0], 2, 2f, 0);
                break;
        }
    }
}
