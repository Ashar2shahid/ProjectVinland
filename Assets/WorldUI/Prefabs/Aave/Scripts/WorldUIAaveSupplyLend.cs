using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldUIAaveSupplyLend : MonoBehaviour
{

    [SerializeField]
    TMP_Text token;

    [SerializeField]
    TMP_InputField inputAmount;

    [SerializeField]
    LendAaveEvent LendEvent;

    public void ButtonAaveLend()
    {
        LendAaveEvent.EventData data = new LendAaveEvent.EventData
        {
            amount = float.Parse(inputAmount.text),
            asset = token.text
        };
        LendEvent.Invoke(data);
    }
}
