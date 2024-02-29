using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState_Player : PlayerBaseState
{
    public void StartState(PlayerMachineController controller, PlayerScrpt saltKnight)
    {
        Debug.Log("Entrou estado andando");
    }

    public void StopState(PlayerMachineController controller, PlayerScrpt saltKnight)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateState(PlayerMachineController controller, PlayerScrpt saltKnight)
    {
        throw new System.NotImplementedException();
    }
}
