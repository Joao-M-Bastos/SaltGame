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
                spawnBehaviour.GerarRound(potencialEnemies[0], 2, 1f, 0);
                break;
            case 2:
                spawnBehaviour.GerarRound(potencialEnemies[0], 2, 0f, 0);
                spawnBehaviour.GerarRound(potencialEnemies[0], 2, 0f, 0.5f);
                break;
            case 3:
                spawnBehaviour.GerarRound(potencialEnemies[0], 4, 1f, 0);
                spawnBehaviour.GerarRound(potencialEnemies[0], 2, 0.5f, 0.7f);
                break;
        }
    }
}
