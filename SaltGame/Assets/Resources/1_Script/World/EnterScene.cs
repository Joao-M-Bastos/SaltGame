using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterScene : MonoBehaviour, InteractiveEntrance
{
    [SerializeField] int sceneCode;

    public void GoToNextPlace(PlayerScrpt player)
    {
        ChangeScene.GoToScene(sceneCode);
    }
}
