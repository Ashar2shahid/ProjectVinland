using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldUISushiSwapMain : MonoBehaviour
{
    //[SerializeField] TMP_Text maticAmount; //Amount of Matic in Users wallet
    [SerializeField] 
    TMP_Dropdown dropdownTop;

    [SerializeField] 
    TMP_Dropdown dropdownBot;

    [SerializeField] 
    TMP_InputField inputTop;

    [SerializeField] 
    TMP_InputField outputBot;

    [SerializeField] 
    SwapExactTokensForTokensEvent SwapEvent;

    public void ButtonSwap()
    {
        SwapExactTokensForTokensEvent.EventData data = new SwapExactTokensForTokensEvent.EventData { amountIn = float.Parse(inputTop.text), 
                                                                                           amountOutMin = float.Parse(outputBot.text),
                                                                                           tokenIn = dropdownTop.options[dropdownTop.value].text,
                                                                                           tokenOut = dropdownBot.options[dropdownBot.value].text
        };

        SwapEvent.Invoke(data);
    }
}
