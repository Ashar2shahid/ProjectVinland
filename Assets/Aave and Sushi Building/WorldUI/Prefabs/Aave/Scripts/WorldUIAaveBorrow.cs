using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldUIAaveBorrow : MonoBehaviour
{
    [SerializeField]
    TMP_Text token;

    [SerializeField]
    TMP_InputField inputAmount;

    [SerializeField]
    BorrowAaveEvent BorrowEvent;

    public void ButtonAaveBorrow()
    {
        BorrowAaveEvent.EventData data = new BorrowAaveEvent.EventData
        {
            amount = float.Parse(inputAmount.text),
            asset = token.text,
            mode = BorrowAaveEvent.IntrestRateMode.Variable
        };
        BorrowEvent.Invoke(data);
    }
}
