using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStatePlayer : PlayerBaseState
{
    public void FixedState(PlayerMachineController controller, PlayerScrpt saltKnight)
    {
        
    }

    public void StartState(PlayerMachineController controller, PlayerScrpt saltKnight)
    {
        Debug.Log("Enter combat state");
    }

    public void StopState(PlayerMachineController controller, PlayerScrpt saltKnight)
    {
        Debug.Log("Exit combat state");
    }

    public void UpdateState(PlayerMachineController controller, PlayerScrpt saltKnight)
    {
        
    }
}
