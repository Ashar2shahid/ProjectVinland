using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack; 


public class SushiUI : MonoBehaviour
{       
    public ModalWindowManager sushiUIModalWindow; 

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        sushiUIModalWindow.OpenWindow();
    }
    void OnTriggerExit(Collider other) {
        sushiUIModalWindow.CloseWindow();
    }
    // Start is called before the first frame update
}
