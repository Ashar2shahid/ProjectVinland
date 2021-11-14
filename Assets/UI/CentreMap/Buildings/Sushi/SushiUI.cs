using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack; 


public class SushiUI : MonoBehaviour
{       
    public ModalWindowManager sushiUIModalWindow;
    public ContractCallInterface contractCallInterface;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        sushiUIModalWindow.OpenWindow();
        Debug.Log(contractCallInterface.convertArgsToString());
    }
    void OnTriggerExit(Collider other) {
        sushiUIModalWindow.CloseWindow();
    }
    // Start is called before the first frame update
}
