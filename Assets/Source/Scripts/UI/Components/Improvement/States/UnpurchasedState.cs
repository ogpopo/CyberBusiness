using UnityEngine;
using UnityEngine.UI;
using Supyrb;

public class UnpurchasedState : _ImprovementState
{
    [SerializeField] private Button purchaseButton;

    private BuyingImprovementsForBusinesSignal buyingImprovementsForBusinesSignal = Signals.Get<BuyingImprovementsForBusinesSignal>();
    private UpdateUIForAllBusinesSignal updateUIForBusinesSignal = Signals.Get<UpdateUIForAllBusinesSignal>();

    public override void InitState(ImprovementController improvementController)
    {
        base.InitState(improvementController);

        State = ImprovementBusinesState.Unpurchased;
    }

    public override void OpenState()
    {
        base.OpenState();

        updateUIForBusinesSignal.Dispatch();

        purchaseButton.onClick.AddListener(() => Buy());
    }

    private void OnDisable()
    {
        purchaseButton.onClick.RemoveListener(() => Buy());
    }

    private void Buy()
    {
        buyingImprovementsForBusinesSignal.Dispatch(improvementController);
    }
}