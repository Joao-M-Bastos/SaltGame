using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterScene : MonoBehaviour, InteractiveEntrance
{
    //ID da cena a carregar
    [SerializeField] int sceneCode;
    [SerializeField] int nextPositionCode;

    public int GetNextPositionCode()
    {
        return nextPositionCode;
    }

    public void GoToNextPlace()
    {
        CommomMetods.GoToScene(sceneCode);
    }
}
