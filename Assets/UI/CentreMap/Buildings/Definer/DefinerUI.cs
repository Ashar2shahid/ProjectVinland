using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefinerUI : MonoBehaviour
{       
    public GameObject DefinerUI2;
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        DefinerUI2.SetActive(true); 
    }
    void OnTriggerExit(Collider other) {
        DefinerUI2.SetActive(false); 
    }
    // Start is called before the first frame update
}
