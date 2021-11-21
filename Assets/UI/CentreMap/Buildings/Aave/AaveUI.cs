using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AaveUI : MonoBehaviour
{       
    public GameObject AaveUI2;
    public GameObject AaveUIText;
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        AaveUIText.SetActive(true);
    }
    void OnTriggerExit(Collider other) {
        AaveUIText.SetActive(false); 
    }
    void Update()
    {
        if(AaveUIText.activeSelf ==true){
        if(Input.GetKeyUp(KeyCode.F) ){
           AaveUIText.SetActive(false); 
           ToggleAaveUI();
        }
        }
    }
    private void ToggleAaveUI(){
        if(AaveUI2.activeSelf == true){
            AaveUI2.SetActive(false);
            AaveUIText.SetActive(true);   
        }else{
            AaveUI2.SetActive(true);
        }
    }
    // Start is called before the first frame update
}
