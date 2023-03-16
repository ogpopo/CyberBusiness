using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum ImprovementBusinesState
{
    Unpurchased,
    Purchased,
}

public class ImprovementController : MonoBehaviour
{
    [SerializeField] private _ImprovementState[] allStates;

    [SerializeField] private TMP_Text improvementIncome;
    [SerializeField] private TMP_Text costBuyingImprovements;

    private Dictionary<ImprovementBusinesState, _ImprovementState> improvementDictionary = new Dictionary<ImprovementBusinesState, _ImprovementState>();
    private Stack<ImprovementBusinesState> stateStory = new Stack<ImprovementBusinesState>();

    private _ImprovementState activeState;

    public TMP_Text ImprovementIncome => improvementIncome;
    public TMP_Text CostBuyingImprovements => costBuyingImprovements;

    public void StartImprovementController()
    {
        if (improvementDictionary.Count != 0)
            return;

        foreach (var ñondition in allStates)
        {
            if (ñondition == null)
                continue;

            ñondition.InitState(this);

            if (improvementDictionary.ContainsKey(ñondition.State))
                continue;

            improvementDictionary.Add(ñondition.State, ñondition);
        }

        foreach (var state in improvementDictionary.Keys)
        {
            improvementDictionary[state].gameObject.SetActive(false);
        }
    }

    public void Init(ImprovementBusinesState state)
    {
        if (!improvementDictionary.ContainsKey(state) || improvementDictionary.Count == 0)
            return;

        if (activeState != null)
            activeState.gameObject.SetActive(false);

        activeState = improvementDictionary[state];
        activeState.gameObject.SetActive(true);
        activeState.OpenState();
    }


}