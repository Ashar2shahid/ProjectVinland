using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniUI : MonoBehaviour
{       
    public GameObject UniUI2;
    public GameObject UniUIText;
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        UniUIText.SetActive(true);
    }
    void OnTriggerExit(Collider other) {
        UniUIText.SetActive(false); 
    }
    void Update()
    {
        if(UniUIText.activeSelf ==true){
        if(Input.GetKeyUp(KeyCode.F) ){
           UniUIText.SetActive(false); 
           ToggleUniUI();
        }
        }
    }
    private void ToggleUniUI(){
        if(UniUI2.activeSelf == true){
            UniUI2.SetActive(false);
            UniUIText.SetActive(true);   
        }else{
            UniUI2.SetActive(true);
        }
    }
    // Start is called before the first frame update
}
