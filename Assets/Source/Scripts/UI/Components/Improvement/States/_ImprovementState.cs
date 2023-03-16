using UnityEngine;

public class _ImprovementState : MonoBehaviour
{
    public ImprovementBusinesState State { get; protected set; }

    protected ImprovementController improvementController;

    public virtual void InitState(ImprovementController improvementController)
    {
        this.improvementController = improvementController;
    }

    public virtual void OpenState()
    {
    }
}