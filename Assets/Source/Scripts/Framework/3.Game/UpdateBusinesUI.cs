using Kuhpik;
using Supyrb;
using System.Linq;
using UnityEngine;

public class UpdateBusinesUI : GameSystem
{
    public override void OnInit()
    {
        base.OnInit();

        Signals.Get<UpdateUIForOpenBusinesSignal>().AddListener(OnUpdateUIForOpenBusines);
        // Signals.Get<UpdateUIForCloseBusines>().AddListener(OnUpdateUIForCloseBusines);
    }

    private void OnUpdateUIForOpenBusines(BusinesController businesController)
    {
        businesController.UnlockPrice.text = config.BaseBusinesPriceDatas.FirstOrDefault(x => x.BusinesId == businesController.BusinesId).Price.ToString() + "$";

        businesController.BusinessLevel.text = player.BusinesLevelData[businesController.BusinesId].ToString();
        businesController.BusinessIncome.text = config.BusinesIncomeDatas.FirstOrDefault(x => x.BusinesId == businesController.BusinesId).BasicIncomeValue * player.BusinesLevelData[businesController.BusinesId] + "$";
        businesController.LevelUpPrice.text = (config.BaseBusinesPriceDatas.FirstOrDefault(x => x.BusinesId == businesController.BusinesId).Price * player.BusinesLevelData[businesController.BusinesId]).ToString();
    }

    //private void OnUpdateUIForCloseBusines(BusinesController businesController)
    //{

    //}
}