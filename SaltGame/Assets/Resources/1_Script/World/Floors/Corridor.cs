using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Corridor : MonoBehaviour
{
    [SerializeField] WaveCaller[] waveCallers;
    [SerializeField] EnterScene goToNextEntrance, goToNextExit;
    [SerializeField] LoadPlayerPosition loadEntrance, loadExit;

    [SerializeField] Transform extraCorridorPoint;

    public void GenerateCorridor(int currentCorridorCount)
    {
        transform.position += new Vector3(0, 300 * currentCorridorCount, 8.5f);
        
        loadEntrance.SetCode(currentCorridorCount * 2);
        loadExit.SetCode((currentCorridorCount * 2) + 1);

        goToNextEntrance.SetNextPositionCode((currentCorridorCount * 2) - 1);        
        goToNextExit.SetNextPositionCode((currentCorridorCount * 2) + 2);

        goToNextEntrance.SetSceneCode(SceneManager.GetActiveScene().buildIndex);
        goToNextExit.SetSceneCode(SceneManager.GetActiveScene().buildIndex);

        GenerateRandomWaveAmount();
    }

    private void GenerateRandomWaveAmount()
    {
        if (waveCallers.Length == 0)
            return;

        int waveAmount = Random.Range(0,waveCallers.Length) + 1;

        while(waveAmount > 0)
        {
            int randomWave = Random.Range(0, waveCallers.Length);

            if (!waveCallers[randomWave].isActiveAndEnabled)
            {
                waveAmount--;
                waveCallers[randomWave].gameObject.SetActive(true);
            }
        }
    }

    public void GenerateExtraCorridor(GameObject extraCorridor)
    {
        Instantiate(extraCorridor, extraCorridorPoint.transform.position, extraCorridor.transform.rotation);
    }

    public void FirstCorridor()
    {
        goToNextEntrance.gameObject.SetActive(false);
    }

    public void LastCorridor()
    {
        goToNextExit.SetNextPositionCode(3);
        goToNextExit.SetSceneCode(1);
    }

    public Vector3 GetEntrancePosition()
    {
        return loadEntrance.transform.position;
    }
}
