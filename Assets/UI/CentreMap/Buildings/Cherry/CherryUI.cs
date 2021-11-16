﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryUI : MonoBehaviour
{       
    public GameObject CherryUI2;
    public GameObject CherryUI2Text;
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        CherryUI2Text.SetActive(true); 
    }
    void OnTriggerExit(Collider other) {
        CherryUI2Text.SetActive(false); 
    }
    void Update()
    {
        if(CherryUI2Text.activeSelf ==true){
        if(Input.GetKeyUp(KeyCode.F) ){
           CherryUI2Text.SetActive(false); 
           ToggleCherryUI();
        }
        }
    }
    private void ToggleCherryUI(){
        if(CherryUI2.activeSelf == true){
            CherryUI2.SetActive(false);
            CherryUI2Text.SetActive(true);   
        }else{
            CherryUI2.SetActive(true);
        }
    }
    // Start is called before the first frame update
}
