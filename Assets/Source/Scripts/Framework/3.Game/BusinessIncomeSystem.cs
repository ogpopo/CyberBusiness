using Kuhpik;
using Supyrb;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class BusinessIncomeSystem : GameSystem
{
    [SerializeField] private float progressFillingRate;

    private Dictionary<BusinesId, int> IncomeProgresDictionary = new Dictionary<BusinesId, int>()
    {
        {BusinesId.Id1, 0},
        {BusinesId.Id2, 0},
        {BusinesId.Id3, 0},
        {BusinesId.Id4, 0},
        {BusinesId.Id5, 0},
    };

    private Coroutine incomeRoutine;

    private ChangeMoneySignal changeMoneySignal = Signals.Get<ChangeMoneySignal>();

    public override void OnInit()
    {
        base.OnInit();

        incomeRoutine = StartCoroutine(StartIncom());
    }

    private IEnumerator StartIncom()
    {
        yield return new WaitForEndOfFrame();

        while (true)
        {
            foreach (var busines in game.BusinesControllers)
            {
                if (busines == null || busines.ActiveState == BusinesState.Close)
                    continue;

                IncomeProgresDictionary[busines.BusinesId]++;

                float value = (float)IncomeProgresDictionary[busines.BusinesId] / config.BusinesIncomeDatas.FirstOrDefault(x => x.BusinesId == busines.BusinesId).IncomeDelay;

                busines.ProgressBar.DOKill();
                busines.ProgressBar.DORewind();
                busines.ProgressBar.DOFillAmount(value, progressFillingRate).OnComplete(() =>
                {
                    if (IncomeProgresDictionary[busines.BusinesId] >= config.BusinesIncomeDatas.FirstOrDefault(x => x.BusinesId == busines.BusinesId).IncomeDelay)
                    {
                        changeMoneySignal.Dispatch(config.BusinesIncomeDatas.FirstOrDefault(x => x.BusinesId == busines.BusinesId).BasicIncomeValue * player.BusinesLevelData[busines.BusinesId]);
                        IncomeProgresDictionary[busines.BusinesId] = 0;

                        busines.ProgressBar.DOKill();
                        busines.ProgressBar.DORewind();
                        busines.ProgressBar.DOFillAmount(0, progressFillingRate);
                    }
                });
            }

            yield return new WaitForSeconds(1);
        }
    }
}