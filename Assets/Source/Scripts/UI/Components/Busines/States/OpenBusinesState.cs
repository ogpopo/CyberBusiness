using Supyrb;
using UnityEngine;
using UnityEngine.UI;

public class OpenBusinesState : _BusinesState
{
    [SerializeField] private Button levelUpButton;

    private BusinesLevelUpSignal businesLevelUpSignal = Signals.Get<BusinesLevelUpSignal>();
    private UpdateUIForOpenBusinesSignal updateUIForOpenBusinesSignal = Signals.Get<UpdateUIForOpenBusinesSignal>();

    public override void InitState(BusinesController businesController)
    {
        base.InitState(businesController);

        State = BusinesState.Open;

        levelUpButton.onClick.AddListener(() => businesLevelUpSignal.Dispatch(businesController));
    }

    private void OnDisable()
    {
        levelUpButton.onClick.RemoveListener(() => businesLevelUpSignal.Dispatch(businesController));
    }

    public override void OpenState()
    {
        base.OpenState();

        updateUIForOpenBusinesSignal.Dispatch(businesController);
    }
}