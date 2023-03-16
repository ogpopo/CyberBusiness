using Kuhpik;
using Supyrb;
using System.Linq;

public class BuyingImprovementsForBusinessSystem : GameSystem
{
    private ChangeMoneySignal changeMoneySignal = Signals.Get<ChangeMoneySignal>();
    private UpdateUIForBusinesSignal updateUIForBusinesSignal = Signals.Get<UpdateUIForBusinesSignal>();

    public override void OnInit()
    {
        base.OnInit();

        Signals.Get<BuyingImprovementsForBusinesSignal>().AddListener(BuyImprovement);
    }

    private void BuyImprovement(ImprovementController improvement)
    {
        BusinesController rightBusiness = null;

        foreach (var busines in game.BusinesControllers)
            if (busines.BusinesImprovementControllers.Contains(improvement))
                rightBusiness = busines;
            else
                return;

        int index = 0;

        for (int i = 0; i < rightBusiness.BusinesImprovementControllers.Length; i++)
        {
            if (rightBusiness.BusinesImprovementControllers.Contains(improvement))
            {
                index = i;
                break;
            }
        }

        var price = config.BusinessImprovementDatas.FirstOrDefault(x => x.BusinesId == rightBusiness.BusinesId).ImprovementDatas[index].Price;

        if (player.PlayerBalance >= price)
        {
            changeMoneySignal.Dispatch(-price);

            improvement.SetActiveState(ImprovementBusinesState.Purchased);

            player.MultiplierFromImprovements[rightBusiness.BusinesId] = (float)(player.MultiplierFromImprovements[rightBusiness.BusinesId] * (100 + config.BusinessImprovementDatas.FirstOrDefault(x =>
            x.BusinesId == rightBusiness.BusinesId).ImprovementDatas[index].InterestIncome) / 100);

            updateUIForBusinesSignal.Dispatch(rightBusiness);
        }
    }
}