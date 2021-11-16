using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MDEXUI : MonoBehaviour
{       
    public GameObject MDEXUI2;
    public GameObject MDEXUIText;
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        MDEXUIText.SetActive(true); 
    }
    void OnTriggerExit(Collider other) {
        MDEXUIText.SetActive(false); 
    }
    void Update()
    {
        if(MDEXUIText.activeSelf ==true){
        if(Input.GetKeyUp(KeyCode.F) ){
           MDEXUIText.SetActive(false); 
           ToggleCherryUI();
        }
        }
    }
    private void ToggleCherryUI(){
        if(MDEXUI2.activeSelf == true){
            MDEXUI2.SetActive(false);
            MDEXUIText.SetActive(true);   
        }else{
            MDEXUI2.SetActive(true);
        }
    }
    // Start is called before the first frame update
}
