using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


[SelectionBase]
public class WorldUISushiLiquidityMain : MonoBehaviour
{
    //Settings
    [SerializeField]
    TMP_Dropdown dropdownTop;
    [SerializeField]
    TMP_Dropdown dropdownBot;
    [SerializeField]
    TMP_InputField inputTop;
    [SerializeField]
    TMP_InputField inputBot;
    [SerializeField]
    Button liquidityButton;
    [SerializeField]
    Image plus;
    [SerializeField]
    WorldUITransaktionStatusPopUp transaktionStatusPopUp;
    [SerializeField]
    AddLiquiditySushiSwapEvent LiquidityEvent;
    [SerializeField]
    TransactionEvents transactionStatusEvent;
    [SerializeField]
    float waitXSecondsPopUp;



    //Functions
    private void Awake()
    {
        transactionStatusEvent.Event += TransactionStatusUpdate;
    }

    public void ButtonAddLiquidity()
    {
        AddLiquiditySushiSwapEvent.EventData data = new AddLiquiditySushiSwapEvent.EventData {
            amountA = float.Parse(inputTop.text),
            amountB = float.Parse(inputBot.text),
            tokenA = dropdownTop.options[dropdownTop.value].text,
            tokenB = dropdownBot.options[dropdownBot.value].text
        };
        LiquidityEvent.Invoke(data);
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
        inputBot.gameObject.SetActive(active);
        liquidityButton.gameObject.SetActive(active);
        plus.gameObject.SetActive(active);
    }
}
