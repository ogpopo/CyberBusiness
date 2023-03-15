using UnityEngine;
using NaughtyAttributes;
using System.Collections.Generic;
using System;

namespace Kuhpik
{
    [CreateAssetMenu(menuName = "Config/GameConfig")]
    public sealed class GameConfig : ScriptableObject
    {
        public List<BusinesPriceData> BaseBusinesPriceDatas = new List<BusinesPriceData>();
    }
}

[Serializable]
public class BusinesPriceData
{
    public BusinesId BusinesId;
    public int Price;
}
