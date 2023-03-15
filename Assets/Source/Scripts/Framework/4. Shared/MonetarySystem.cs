using UnityEngine;
using Kuhpik;
using DG.Tweening;
using System;
using Supyrb;

public class MonetarySystem : GameSystemWithScreen<PlayerBalanceUI>
{
    private Tween moneyTween;

    public override void OnInit()
    {
        Signals.Get<ChangeMoneySignal>().AddListener(ChangedMoney);

        UpdateUI();
    }

    private void ChangedMoney(int value)
    {
        player.PlayerBalance += value;
        UpdateUI();

        Bootstrap.Instance.SaveGame();
    }

    private void UpdateUI()
    {
        ChangeMoneyEffect(player.PlayerBalance, 0.3f);
    }

    private void ChangeMoneyEffect(int to, float time)
    {
        DOTween.Kill(moneyTween);

        int changableValue = Int32.Parse(screen.MoneyCount.text);
        moneyTween = DOTween.To(() => changableValue, x => changableValue = x, to, time).OnUpdate(() =>
        {
            screen.MoneyCount.text = changableValue.ToString() + "$";
        });
    }
}