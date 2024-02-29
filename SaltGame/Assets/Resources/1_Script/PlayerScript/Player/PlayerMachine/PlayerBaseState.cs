using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerBaseState
{
    public void UpdateState(PlayerMachineController controller, PlayerScrpt saltKnight);

    public void StartState(PlayerMachineController controller, PlayerScrpt saltKnight);

    public void StopState(PlayerMachineController controller, PlayerScrpt saltKnight);
}
