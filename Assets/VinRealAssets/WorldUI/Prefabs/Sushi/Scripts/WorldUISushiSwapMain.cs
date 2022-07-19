using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


[SelectionBase]
public class WorldUISushiSwapMain : MonoBehaviour
{
    //Settings
    [SerializeField]
    TMP_Dropdown dropdownTop;
    [SerializeField]
    TMP_Dropdown dropdownBot;
    [SerializeField]
    TMP_InputField inputTop;
    [SerializeField]
    TMP_InputField outputBot;
    [SerializeField]
    Button swapButton;
    [SerializeField]
    Button maxButton;
    [SerializeField]
    Image arrow;
    [SerializeField]
    WorldUITransaktionStatusPopUp transaktionStatusPopUp;
    [SerializeField]
    SwapExactTokensForTokensEvent SwapEvent;
    [SerializeField]
    TransactionEvents transactionStatusEvent;
    [SerializeField]
    float waitXSecondsPopUp;


    //Functions
    private void Awake()
    {
        transactionStatusEvent.Event += TransactionStatusUpdate;
    }

    public void ButtonSwap()
    {
        SwapExactTokensForTokensEvent.EventData data = new SwapExactTokensForTokensEvent.EventData {
            amountIn = float.Parse(inputTop.text),
            amountOutMin = float.Parse(outputBot.text),
            tokenIn = dropdownTop.options[dropdownTop.value].text,
            tokenOut = dropdownBot.options[dropdownBot.value].text
        };
        SwapEvent.Invoke(data);
    }

    private void TransactionStatusUpdate(TransactionEvents.EventData status)
    {
        ChangeActive(false);
        transaktionStatusPopUp.ShowStatus(status.action);
        if (status.action == TransactionEvents.TransactionActions.Finished || status.action == TransactionEvents.TransactionActions.Failed)
        {
            StartCoroutine(ChangeActiveDelayed(true, waitXSecondsPopUp));
        }
    }

    IEnumerator ChangeActiveDelayed(bool active, float delay)
    {
        yield return new WaitForSeconds(delay);
        ChangeActive(active);
        transaktionStatusPopUp.Hide();
    }

    public void ChangeActive(bool active)
    {
        dropdownTop.gameObject.SetActive(active);
        inputTop.gameObject.SetActive(active);
        dropdownBot.gameObject.SetActive(active);
        outputBot.gameObject.SetActive(active);
        swapButton.gameObject.SetActive(active);
        maxButton.gameObject.SetActive(active);
        arrow.gameObject.SetActive(active);
    }
}
