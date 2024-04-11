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
    }

    public static int GetScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
}
