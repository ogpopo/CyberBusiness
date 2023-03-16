using UnityEngine;
using UnityEngine.UI;
using Supyrb;

public class CloseBusinesState : _BusinesState
{
    [SerializeField] private Button unlockButton;

    private BusinesUnlockSignal businesUnlockSignal = Signals.Get<BusinesUnlockSignal>();
    private UpdateUIForBusinesSignal updateUIForBusinesSignal = Signals.Get<UpdateUIForBusinesSignal>();

    public override void InitState(BusinesController businesController)
    {
        base.InitState(businesController);

        State = BusinesState.Close;
    }

    public override void OpenState()
    {
        base.OpenState();

        updateUIForBusinesSignal.Dispatch(businesController);

        unlockButton.onClick.AddListener(OnUnlock);
    }

    private void OnDisable()
    {
        unlockButton.onClick.RemoveListener(OnUnlock);
    }

    private void OnUnlock()
    {
        businesUnlockSignal.Dispatch(businesController);
    }
}