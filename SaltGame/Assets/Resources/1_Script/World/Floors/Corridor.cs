using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Corridor : MonoBehaviour
{
    [SerializeField] WaveCaller[] waveCaller;
    [SerializeField] EnterScene goToNextEntrance, goToNextExit;
    [SerializeField] LoadPlayerPosition loadEntrance, loadExit;

    public void GenerateCorridor(int currentCorridorCount)
    {
        transform.position += new Vector3(100 * currentCorridorCount, 0, 8.5f);
        
        loadEntrance.SetCode(currentCorridorCount * 2);
        loadExit.SetCode((currentCorridorCount * 2) + 1);

        goToNextEntrance.SetNextPositionCode((currentCorridorCount * 2) - 1);        
        goToNextExit.SetNextPositionCode((currentCorridorCount * 2) + 2);

        goToNextEntrance.SetSceneCode(SceneManager.GetActiveScene().buildIndex);
        goToNextExit.SetSceneCode(SceneManager.GetActiveScene().buildIndex);
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
