using System;
using UnityEngine;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Kuhpik
{
    /// <summary>
    /// Used to store game data. Change it the way you want.
    /// </summary>
    [Serializable]
    public class GameData
    {
        public List<BusinesController> BusinesControllers = new List<BusinesController>();
        //public List<BusinesController> OpenBusinesses => BusinesControllers.Where(x => x.ActiveState == BusinesState.Open).ToList();
    }
}