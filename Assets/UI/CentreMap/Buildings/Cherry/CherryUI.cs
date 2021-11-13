using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryUI : MonoBehaviour
{       
    public GameObject CherryUI2;
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        CherryUI2.SetActive(true); 
    }
    void OnTriggerExit(Collider other) {
        CherryUI2.SetActive(false); 
    }
    // Start is called before the first frame update
}
