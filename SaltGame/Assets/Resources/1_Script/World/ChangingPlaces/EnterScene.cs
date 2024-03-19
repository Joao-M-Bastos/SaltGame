using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterScene : MonoBehaviour, InteractiveEntrance
{
    //ID da cena a carregar
    [SerializeField] int sceneCode;
    [SerializeField] int nextPositionCode;
    bool nextScene;

    private void Awake()
    {
        nextScene = true;
    }

    public int GetNextPositionCode()
    {
        return nextPositionCode;
    }

    public void SetNextSceneToFalse()
    {
        nextScene = false;
    }

    public void GoToNextPlace()
    {
        if (nextScene)
            GoToNextScene();
    }

    public void GoToNextScene()
    {
        CommomMetods.GoToScene(sceneCode);
    }
}
