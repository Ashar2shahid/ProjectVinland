using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AaveUI : MonoBehaviour
{       
    public GameObject AaveUI2;
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        AaveUI2.SetActive(true); 
    }
    void OnTriggerExit(Collider other) {
        AaveUI2.SetActive(false); 
    }
    // Start is called before the first frame update
}
