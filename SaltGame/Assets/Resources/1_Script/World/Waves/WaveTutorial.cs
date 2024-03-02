using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTutorial : Wave
{

    public override void GenerateRound()
    {
        //GameObject enemy, int amount, float inteval, float cooldown

        currentRoundNumber++;

        switch (currentRoundNumber)
        {
            case 1:
                spawnBehaviour.GerarRound(potencialEnemies[0], 6, 1f, 0);
                break;
            case 2:
                spawnBehaviour.GerarRound(potencialEnemies[0], 2, 0.5f, 0);
                break;
        }
    }
}
