using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDemo : MonoBehaviour
{

    [SerializeField] TMP_Text leftScreen;
    [SerializeField] TMP_Dropdown dropdownTop;
    [SerializeField] TMP_Dropdown dropdownBottom;
    [SerializeField] TMP_InputField inputTop;
    [SerializeField] TMP_InputField outputBottom;

    private float inputAmount;
    private List<string>m_DropOptions = new List<string>{"SintorasCoin", "VincentCoin", "PowerParadiseDelightCoin"};

    void Start()
    {
        dropdownBottom.ClearOptions();
        dropdownTop.ClearOptions();
        dropdownTop.AddOptions(m_DropOptions);
        dropdownBottom.AddOptions(m_DropOptions);
    }

    public void Swap()
    {
        leftScreen.text = "You've successfully exchanged  " + inputAmount +" "+ dropdownTop.options[dropdownTop.value].text + "s for " + Convert().ToString()+" "+dropdownBottom.options[dropdownBottom.value].text + "s!";
        //Debug.Log("pressed");
    }
    public void SetInputAmount()
    {
        inputAmount = Mathf.Round(float.Parse(inputTop.text)*1000)/1000f;
        outputBottom.text = Convert().ToString();
            //Convert().ToString());
    }

    private float Convert()
    {
        switch (dropdownTop.options[dropdownTop.value].text)
        {
            case "SintorasCoin":
                if (dropdownBottom.options[dropdownBottom.value].text == "VincentCoin")
                {
                    return inputAmount / 2;
                }
                else if (dropdownBottom.options[dropdownBottom.value].text == "PowerParadiseDelightCoin")
                {
                    return inputAmount * 2;
                }
                else return inputAmount;
            case "VincentCoint":
                if (dropdownBottom.options[dropdownBottom.value].text == "SintorasCoin")
                {
                    return inputAmount * 2;
                }
                else if (dropdownBottom.options[dropdownBottom.value].text == "PowerParadiseDelightCoin")
                {
                    return inputAmount * 4;
                }
                else return inputAmount;

            case "PowerParadiseDelightCoin":
                if (dropdownBottom.options[dropdownBottom.value].text == "VincentCoin")
                {
                    return inputAmount / 4;
                }
                else if (dropdownBottom.options[dropdownBottom.value].text == "SintorasCoin")
                {
                    return inputAmount / 2;
                }
                else return inputAmount;

            default:
                return 0;

        }
    }
}
