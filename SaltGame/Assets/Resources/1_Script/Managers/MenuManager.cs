using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] int sceneCode;

    public void GoToNextPlace()
    {
        ChangeScene.GoToScene(sceneCode);
    }
}
