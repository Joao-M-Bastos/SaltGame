using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState_Player : PlayerBaseState
{
    public void FixedState(PlayerMachineController controller, PlayerScrpt saltKnight)
    {
        if (saltKnight.Direction != 0)
        {
            saltKnight.playerRB.AddForce(saltKnight.transform.forward * saltKnight.Speed, ForceMode.VelocityChange);
        }
        else
        {
            saltKnight.playerRB.velocity *= 0.8f;
        }
    }

    public void StartState(PlayerMachineController controller, PlayerScrpt saltKnight)
    {
        Debug.Log("Entrou estado andando");
    }

    public void StopState(PlayerMachineController controller, PlayerScrpt saltKnight)
    {
        Debug.Log("Saiu estado andando");
    }

    public void UpdateState(PlayerMachineController controller, PlayerScrpt saltKnight)
    {
        

        TryChangeState();
    }

    private void TryChangeState()
    {
        
    }
}
