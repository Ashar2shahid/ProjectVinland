using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldUIAaveBorrowRepay : MonoBehaviour
{
    [SerializeField]
    TMP_Text token;

    [SerializeField]
    TMP_InputField inputAmount;

    [SerializeField]
    RepayAaveEvent RepayEvent;

    public void ButtonAaveRepay()
    {
        RepayAaveEvent.EventData data = new RepayAaveEvent.EventData
        {
            amount = float.Parse(inputAmount.text),
            asset = token.text,
            rateMode = RepayAaveEvent.IntrestRateMode.Variable
        };
        RepayEvent.Invoke(data);
    }
}
