using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface para jogador verificar se h� uma entrada interativa
public interface InteractiveEntrance
{
    public void GoToNextPlace();

    //Case ele aperte Espa�o ele chama esse metodo, que leva o jogador
    public void GoToNextScene();

    public int GetNextPositionCode();
}
