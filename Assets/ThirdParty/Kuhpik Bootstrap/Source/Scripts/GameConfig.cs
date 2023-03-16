using UnityEngine;
using System.Collections.Generic;
using System;

namespace Kuhpik
{
    [CreateAssetMenu(menuName = "Config/GameConfig")]
    public sealed class GameConfig : ScriptableObject
    {
        public List<BusinesPriceData> BaseBusinesPriceDatas = new List<BusinesPriceData>();
        public List<BusinesIncomeData> BusinesIncomeDatas = new List<BusinesIncomeData>();
        public BusinessImprovementData[] BusinessImprovementDatas = new BusinessImprovementData[2];
    }
}

[Serializable]
public class BusinesPriceData
{
    public BusinesId BusinesId;
    public int Price;
}

[Serializable]
public class BusinesIncomeData
{
    public BusinesId BusinesId;
    public int IncomeDelay;
    public int BasicIncomeValue;
}

[Serializable]
public class BusinessImprovementData
{
    public BusinesId BusinesId;
    public ImprovementData[] ImprovementDatas = new ImprovementData[2];

    public class ImprovementData
    {
        public int Price;
        [Range(0, 100)] public int InterestIncome;
    }
}