using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public GameObject player;
    public GameObject contractcall;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("test");
        Debug.Log(other.name);
        if(other.name == "Launchpad"){
        player.transform.position = target.transform.position;
        } else {
            contractcall.SetActive(true);
            Debug.Log("test 2 ");
        }
    }

        
}
