using Kuhpik;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BusinesId
{
    Id1,
    Id2,
    Id3,
    Id4,
    Id5,
}

public enum BusinesState
{
    Close,
    Open
}

public class BusinesController : MonoBehaviour
{
    [SerializeField] private _BusinesState[] allStates;
    [SerializeField] private BusinesId businesId;

    [SerializeField] private ImprovementController[] businesImprovementControllers = new ImprovementController[2];

    [SerializeField] private Image progressBar;
    [SerializeField] private TMP_Text businessLevel;
    [SerializeField] private TMP_Text businessIncome;
    [SerializeField] private TMP_Text levelUpPrice;
    [SerializeField] private List<DataUIImprovements> dataUIImprovements;

    [SerializeField] private TMP_Text unlockPrice;

    private Dictionary<BusinesState, _BusinesState> businesDictionary = new Dictionary<BusinesState, _BusinesState>();
    private Stack<BusinesState> busineshiStory = new Stack<BusinesState>();

    private _BusinesState activeState;

    public BusinesId BusinesId => businesId;

    public ImprovementController[] BusinesImprovementControllers => businesImprovementControllers;

    public Image ProgressBar => progressBar;
    public TMP_Text BusinessLevel => businessLevel;
    public TMP_Text BusinessIncome => businessIncome;
    public TMP_Text LevelUpPrice => levelUpPrice;
    public List<DataUIImprovements> DataUIImprovements => dataUIImprovements;

    public TMP_Text UnlockPrice => unlockPrice;

    public BusinesState ActiveState => activeState.State;

    public void StartBusinesController()
    {
        if (businesDictionary.Count != 0)
            return;

        foreach (var ñondition in allStates)
        {
            if (ñondition == null)
                continue;

            ñondition.InitState(this);

            if (businesDictionary.ContainsKey(ñondition.State))
                continue;

            businesDictionary.Add(ñondition.State, ñondition);
        }

        foreach (var state in businesDictionary.Keys)
        {
            businesDictionary[state].gameObject.SetActive(false);
        }
    }

    public void Init(BusinesState state)
    {
        if (!businesDictionary.ContainsKey(state) || businesDictionary.Count == 0)
            return;

        if (activeState != null)
            activeState.gameObject.SetActive(false);

        activeState = businesDictionary[state];
        activeState.gameObject.SetActive(true);
        activeState.OpenState();
    }

    public void SetActiveState(BusinesState newState)
    {
        if (!businesDictionary.ContainsKey(newState))
            return;

        if (activeState != null)
        {
            activeState.gameObject.SetActive(false);
        }

        activeState = businesDictionary[newState];
        activeState.gameObject.SetActive(true);
        activeState.OpenState();

        Bootstrap.Instance.PlayerData.BusinesDataDictionary[businesId] = newState;
        Bootstrap.Instance.SaveGame();
    }

    public void IncomeProgressing()
    {
    }
}

public class DataUIImprovements
{
    public TMP_Text ImprovementsIncome;
    public TMP_Text ImprovementsPurchasePrice;
}