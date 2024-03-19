using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface para jogador verificar se há uma entrada interativa
public interface InteractiveEntrance
{
    public void GoToNextPlace();

    //Case ele aperte Espaço ele chama esse metodo, que leva o jogador
    public void GoToNextScene();

    public int GetNextPositionCode();
}
