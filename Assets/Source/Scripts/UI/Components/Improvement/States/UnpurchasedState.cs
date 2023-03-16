using UnityEngine;
using UnityEngine.UI;
using Supyrb;
using TMPro;

public class UnpurchasedState : _ImprovementState
{
    public override void InitState(ImprovementController improvementController)
    {
        base.InitState(improvementController);

        State = ImprovementBusinesState.Unpurchased;
    }

    public override void OpenState()
    {
        base.OpenState();
    }
}