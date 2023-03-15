using Supyrb;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBusinesState : _BusinesState
{
    private UpdateUIForOpenBusinesSignal updateUIForOpenBusinesSignal = Signals.Get<UpdateUIForOpenBusinesSignal>();

    public override void InitState(BusinesController businesController)
    {
        base.InitState(businesController);

        State = BusinesState.Open;
    }

    public override void OpenState()
    {
        base.OpenState();

        updateUIForOpenBusinesSignal.Dispatch(businesController);
    }
}