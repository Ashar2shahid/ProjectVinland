using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFTMinterUI : MonoBehaviour
{
    public GameObject NFTMinter;
    public GameObject NFTMinterText;
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        NFTMinterText.SetActive(true); 
    }
    void OnTriggerExit(Collider other) {
        NFTMinterText.SetActive(false); 
    }
    void Update()
    {
        if(NFTMinterText.activeSelf ==true){
        if(Input.GetKeyUp(KeyCode.F) ){
           NFTMinterText.SetActive(false); 
           ToggleCherryUI();
        }
        }
    }
    private void ToggleCherryUI(){
        if(NFTMinter.activeSelf == true){
            NFTMinter.SetActive(false);
            NFTMinterText.SetActive(true);   
        }else{
            NFTMinter.SetActive(true);
        }
    }
}
