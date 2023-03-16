using Kuhpik;
using Supyrb;
using System.Linq;

public class UpdateBusinesUI : GameSystem
{
    public override void OnInit()
    {
        base.OnInit();

        Signals.Get<UpdateUIForBusinesSignal>().AddListener(OnUpdateUIForBusines);
    }

    private void OnUpdateUIForBusines(BusinesController businesController)
    {
        businesController.UnlockPrice.text = config.BaseBusinesPriceConfig.FirstOrDefault(x => x.BusinesId == businesController.BusinesId).Price.ToString() + "$";

        businesController.BusinessLevel.text = player.BusinesLevelData[businesController.BusinesId].ToString();

        businesController.BusinessIncome.text = config.BusinesIncomeConfig.FirstOrDefault(x =>
        x.BusinesId == businesController.BusinesId).BasicIncomeValue * player.BusinesLevelData[businesController.BusinesId] + "$";

        businesController.LevelUpPrice.text = (config.BaseBusinesPriceConfig.FirstOrDefault(x =>
        x.BusinesId == businesController.BusinesId).Price * player.BusinesLevelData[businesController.BusinesId]).ToString() + "$";

        for (int i = 0; i < businesController.BusinesImprovementControllers.Length; i++)
        {
            businesController.BusinesImprovementControllers[i].ImprovementIncome.text = config.BusinessImprovementDatas.FirstOrDefault(x =>
            x.BusinesId == businesController.BusinesId).ImprovementDatas[i].InterestIncome.ToString() + "%";

            businesController.BusinesImprovementControllers[i].CostBuyingImprovements.text = config.BusinessImprovementDatas.FirstOrDefault(x =>
            x.BusinesId == businesController.BusinesId).ImprovementDatas[i].Price.ToString() + "$";
        }
    }
}