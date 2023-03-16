using UnityEngine;

public class _BusinesState : MonoBehaviour
{
    public BusinesState State { get; protected set; }

    protected BusinesController businesController;

    public virtual void InitState(BusinesController businesController)
    {
        this.businesController = businesController;
    }

    //public virtual void StartState()
    //{
    //}

    public virtual void OpenState()
    {
    }
}