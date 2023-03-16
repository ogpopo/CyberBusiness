using System;
using System.Collections.Generic;

namespace Kuhpik
{
    /// <summary>
    /// Used to store player's data. Change it the way you want.
    /// </summary>
    [Serializable]
    public class PlayerData
    {
        public Dictionary<BusinesId, BusinesState> BusinesDataDictionary;
        public Dictionary<BusinesId, int> BusinesLevelData = new Dictionary<BusinesId, int>()
        {
                {BusinesId.Id1, 1},
                {BusinesId.Id2, 1},
                {BusinesId.Id3, 1},
                {BusinesId.Id4, 1},
                {BusinesId.Id5, 1},
        };

        public Dictionary<BusinesId, ImprovementBusinesState[]> BusinessImprovementDataDictinary = new Dictionary<BusinesId, ImprovementBusinesState[]>()
        {
            { BusinesId.Id1, new ImprovementBusinesState[2] },
            { BusinesId.Id2, new ImprovementBusinesState[2] },
            { BusinesId.Id3, new ImprovementBusinesState[2] },
            { BusinesId.Id4, new ImprovementBusinesState[2] },
            { BusinesId.Id5, new ImprovementBusinesState[2] },
        };

        public int PlayerBalance = 0;
    }

    //public class BusinessImprovementData
    //{

    //}
}