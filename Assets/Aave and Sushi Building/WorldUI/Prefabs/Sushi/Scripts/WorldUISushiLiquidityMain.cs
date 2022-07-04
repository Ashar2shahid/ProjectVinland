using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldUISushiLiquidityMain : MonoBehaviour
{
    [SerializeField]
    TMP_Dropdown dropdownTop;

    [SerializeField]
    TMP_Dropdown dropdownBot;

    [SerializeField]
    TMP_InputField inputTop;

    [SerializeField]
    TMP_InputField inputBot;

    [SerializeField]
    AddLiquiditySushiSwapEvent LiquidityEvent;

    public void ButtonAddLiquidity()
    {
        AddLiquiditySushiSwapEvent.EventData data = new AddLiquiditySushiSwapEvent.EventData
        {
            amountA = float.Parse(inputTop.text),
            amountB = float.Parse(inputBot.text),
            tokenA = dropdownTop.options[dropdownTop.value].text,
            tokenB = dropdownBot.options[dropdownBot.value].text
        };
        LiquidityEvent.Invoke(data);
    }
}
