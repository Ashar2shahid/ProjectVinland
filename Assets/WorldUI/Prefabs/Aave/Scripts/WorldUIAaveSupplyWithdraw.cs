using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldUIAaveSupplyWithdraw : MonoBehaviour
{
    [SerializeField]
    TMP_Text token;

    [SerializeField]
    TMP_InputField inputAmount;

    [SerializeField]
    WithdrawAaveEvent WithdrawEvent;

    public void ButtonAaveWithdraw()
    {
        WithdrawAaveEvent.EventData data = new WithdrawAaveEvent.EventData
        {
            amount = float.Parse(inputAmount.text),
            asset = token.text
        };
        WithdrawEvent.Invoke(data);
    }
}

