using UnityEngine;
using System.Collections.Generic;
using System;

namespace Kuhpik
{
    [CreateAssetMenu(menuName = "Config/GameConfig")]
    public sealed class GameConfig : ScriptableObject
    {
        public List<BusinesPriceConfig> BaseBusinesPriceConfig = new List<BusinesPriceConfig>();
        public List<BusinesIncomeConfig> BusinesIncomeConfig = new List<BusinesIncomeConfig>();
        public BusinessImprovementConfig[] BusinessImprovementDatas = new BusinessImprovementConfig[2];
    }
}

[Serializable]
public class BusinesPriceConfig
{
    public BusinesId BusinesId;
    public int Price;
}

[Serializable]
public class BusinesIncomeConfig
{
    public BusinesId BusinesId;
    public int IncomeDelay;
    public int BasicIncomeValue;
}

[Serializable]
public class BusinessImprovementConfig
{
    public BusinesId BusinesId;
    public ImprovementData[] ImprovementDatas = new ImprovementData[2];

    [Serializable]
    public class ImprovementData
    {
        public int InterestIncome;
        public int Price;
    }
}