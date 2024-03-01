using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingState_Player : PlayerBaseState
{
    public void FixedState(PlayerMachineController controller, PlayerScrpt saltKnight)
    {
        if (saltKnight.Direction != 0 && Mathf.Abs(saltKnight.playerRB.velocity.x) < saltKnight.Speed)
        {
            saltKnight.playerRB.AddForce(saltKnight.transform.forward * Time.deltaTime, ForceMode.VelocityChange);
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
