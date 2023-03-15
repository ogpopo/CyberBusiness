using Kuhpik;
using Supyrb;
using System.Linq;
using UnityEngine;

public class BusinesUnlockSystem : GameSystem
{
    private ChangeMoneySignal changeMoneySignal = Signals.Get<ChangeMoneySignal>();

    public override void OnInit()
    {
        base.OnInit();

        Signals.Get<BusinesUnlockSignal>().AddListener(Unlock);
    }

    private void Unlock(BusinesController busines)
    {       
        var price = config.BaseBusinesPriceDatas.FirstOrDefault(x => x.BusinesId == busines.BusinesId).Price
            * player.BusinesLevelData[busines.BusinesId];

        if (player.PlayerBalance >= price)
        {
            changeMoneySignal.Dispatch(-price);
            busines.SetActiveState(BusinesState.Open);  
        }
    }
}