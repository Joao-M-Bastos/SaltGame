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
        saltKnight.SetShildCollider(true);
        saltKnight.FullRest();
        CanvasManager.GetInstance().ChangeCanvas(CanvasStates.Battle);
        SoundManager.GetInstance().PlayBattleSound();
    }

    public void StopState(PlayerMachineController controller, PlayerScrpt saltKnight)
    {
        saltKnight.SetShildCollider(false);
        saltKnight.DeactivateItems();
        SoundManager.GetInstance().StopBattleSound();
    }

    public void UpdateState(PlayerMachineController controller, PlayerScrpt saltKnight)
    {
        if (Input.GetMouseButtonDown(0))
        {
            saltKnight.ActivateSword();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            saltKnight.ActivateItem(1);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            saltKnight.ActivateItem(0);
        }

        saltKnight.Rest();
    }
}
