using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefinerUI : MonoBehaviour
{       
    public GameObject DefinerUI2;
    public GameObject DefinerUI2Text;
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        DefinerUI2Text.SetActive(true); 
    }
    void OnTriggerExit(Collider other) {
        DefinerUI2Text.SetActive(false); 
    }
    void Update()
    {
        if(DefinerUI2Text.activeSelf ==true){
        if(Input.GetKeyUp(KeyCode.F) ){
           DefinerUI2Text.SetActive(false); 
           ToggleCherryUI();
        }
        }
    }
    private void ToggleCherryUI(){
        if(DefinerUI2.activeSelf == true){
            DefinerUI2.SetActive(false);
            DefinerUI2Text.SetActive(true);   
        }else{
            DefinerUI2.SetActive(true);
        }
    }
    // Start is called before the first frame update
}
