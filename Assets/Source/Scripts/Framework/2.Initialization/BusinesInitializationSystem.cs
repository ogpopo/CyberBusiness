using Kuhpik;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BusinesInitializationSystem : GameSystem
{
    private List<BusinesController> allBusines => game.BusinesControllers;

    public async override void OnInit()
    {
        base.OnInit();

        foreach (var busines in allBusines)
            busines.StartBusinesController();

        if (player.BusinesDataDictionary == null)
        {
            player.BusinesDataDictionary = new Dictionary<BusinesId, BusinesState>()
            {
                {BusinesId.Id1, BusinesState.Open},
                {BusinesId.Id2, BusinesState.Close},
                {BusinesId.Id3, BusinesState.Close},
                {BusinesId.Id4, BusinesState.Close},
                {BusinesId.Id5, BusinesState.Close},
            };
        }

        await Task.Delay(10);

        UploadingBusinesses();

        Bootstrap.Instance.SaveGame();
    }

    private void UploadingBusinesses()
    {
        foreach (var businesController in allBusines)
        {
            player.BusinesDataDictionary.TryGetValue(businesController.BusinesId, out BusinesState businesState);
            businesController.Init(businesState);
        }
    }
}