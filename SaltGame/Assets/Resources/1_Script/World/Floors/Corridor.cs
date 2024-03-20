using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Corridor : MonoBehaviour
{
    [SerializeField] WaveCaller[] waveCaller;
    [SerializeField] EnterScene goToNextEntrance, goToNextExit;
    [SerializeField] LoadPlayerPosition loadEntrance, loadExit;

    public void GenerateCorridor(int currentCorridorCount, bool lastCorridor = false)
    {
        transform.position += new Vector3(100 * currentCorridorCount, 0, 0);

        if(currentCorridorCount == 0)
        {
            goToNextEntrance.gameObject.SetActive(false);
        }
        
        loadEntrance.SetCode(currentCorridorCount * 2);
        loadExit.SetCode((currentCorridorCount * 2) + 1);

        goToNextEntrance.SetNextPositionCode(1 + (currentCorridorCount * 2));

        if (lastCorridor)
        {
            goToNextExit.SetNextPositionCode(0);
        }
        else
        {
            goToNextExit.SetNextPositionCode((currentCorridorCount * 2) + 2);
            SetNextSceneToFalse();
        }
    }

    public void SetNextSceneToFalse()
    {
        goToNextEntrance.SetNextSceneToFalse();
        goToNextExit.SetNextSceneToFalse();
    }

    public Vector3 GetEntrancePosition()
    {
        return loadEntrance.transform.position;
    }
}
