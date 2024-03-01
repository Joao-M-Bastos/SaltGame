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
            //Se a velociade dele for maior que a permitida ele não acelera
            if (Mathf.Abs(saltKnight.playerRB.velocity.x) > saltKnight.Speed) return;
            //Acelera pra frente
            saltKnight.playerRB.AddForce(saltKnight.transform.forward / 5, ForceMode.VelocityChange);
        }
        else
        {
            //Para o jogador para mais rapidamente
            saltKnight.playerRB.velocity *= 0.6f;
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
