using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Classe estatica pode ser acessada por qualquer um sem necessidade de instanciar
public static class CommomMetods
{
    public static void GoToScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
        GameManager.GetInstance().ResetDestroyedWaveNum();
        GameManager.GetInstance().SetLoadedInScene(false);

    }

    public static int GetSceneCode()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
