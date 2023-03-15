using Kuhpik;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoadingSystem : GameSystem
{
    [SerializeField] private List<BusinesController> businesControllers = new List<BusinesController>();

    public override void OnInit()
    {
        base.OnInit();

        game.BusinesControllers = businesControllers/*GameObject.FindObjectsOfType<BusinesController>().ToList()*/;

        //print(game.BusinesControllers.Count);
    }
}