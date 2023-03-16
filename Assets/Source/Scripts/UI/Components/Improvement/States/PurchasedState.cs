using UnityEngine;
using UnityEngine.UI;
using Supyrb;
using TMPro;

public class PurchasedState : _ImprovementState
{
    public override void InitState(ImprovementController improvementController)
    {
        base.InitState(improvementController);

        State = ImprovementBusinesState.Purchased;
    }

    public override void OpenState()
    {
        base.OpenState();
    }
}