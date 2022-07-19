using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUISushiHelp : MonoBehaviour
{
    [SerializeField] private GameObject SelectTokenButton;
    [SerializeField] private GameObject EnterInputOutputButton;
    [SerializeField] private GameObject ApproveButton;
    [SerializeField] private GameObject SwapButton;

    [SerializeField] private GameObject SelectTokenHelp;
    [SerializeField] private GameObject EnterInputOutputHelp;
    [SerializeField] private GameObject ApproveHelp1;
    [SerializeField] private GameObject ApproveHelp2;
    [SerializeField] private GameObject SwapHelp1;
    [SerializeField] private GameObject SwapHelp2;


    public void ButtonClick()
    {
        SelectTokenButton.gameObject.SetActive(false);
        EnterInputOutputButton.gameObject.SetActive(false);
        ApproveButton.gameObject.SetActive(false);
        SwapButton.gameObject.SetActive(false);
    }

    public void Back()
    {
        SelectTokenButton.gameObject.SetActive(true);
        EnterInputOutputButton.gameObject.SetActive(true);
        ApproveButton.gameObject.SetActive(true);
        SwapButton.gameObject.SetActive(true);

        SelectTokenHelp.gameObject.SetActive(false);
        EnterInputOutputHelp.gameObject.SetActive(false);
        ApproveHelp1.gameObject.SetActive(false);
        ApproveHelp2.gameObject.SetActive(false);
        SwapHelp1.gameObject.SetActive(false);
        SwapHelp2.gameObject.SetActive(false);
    }

    public void SelectTokenButtonClick() 
    {
        ButtonClick();
        SelectTokenHelp.gameObject.SetActive(true);
    }    
    public void EnterInputOutputButtonClick() 
    {
        ButtonClick();
        EnterInputOutputHelp.gameObject.SetActive(true);
    }   
    public void ApproveButtonClick1() 
    {
        ButtonClick();
        ApproveHelp1.gameObject.SetActive(true);
        ApproveHelp2.gameObject.SetActive(false);
    }  
    public void ApproveButtonClick2() 
    {
        ApproveHelp1.gameObject.SetActive(false); 
        ApproveHelp2.gameObject.SetActive(true);
    }  
    public void SwapButtonClick1() 
    {
        ButtonClick();
        SwapHelp1.gameObject.SetActive(true);
        SwapHelp2.gameObject.SetActive(false);
    }
    public void SwapButtonClick2()
    {
        SwapHelp1.gameObject.SetActive(false);
        SwapHelp2.gameObject.SetActive(true);
    }
}
