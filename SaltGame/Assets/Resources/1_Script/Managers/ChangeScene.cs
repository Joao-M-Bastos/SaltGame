using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ChangeScene
{
    public static void GoToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
