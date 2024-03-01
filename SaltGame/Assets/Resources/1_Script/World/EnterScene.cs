using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterScene : MonoBehaviour, InteractiveEntrance
{
    //ID da cena a carregar
    [SerializeField] int sceneCode;

    public void GoToNextPlace(PlayerScrpt player)
    {
        CommomMetods.GoToScene(sceneCode);
    }
}
