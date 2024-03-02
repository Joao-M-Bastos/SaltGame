using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface para jogador verificar se há uma entrada interativa
public interface InteractiveEntrance
{
    //Case ele aperte Espaço ele chama esse metodo, que leva o jogador
    public void GoToNextPlace();

    public int GetNextPositionCode();
}
