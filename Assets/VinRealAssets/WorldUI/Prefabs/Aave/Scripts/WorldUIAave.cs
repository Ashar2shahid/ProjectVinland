using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUIAave : MonoBehaviour
{
    [SerializeField] private GameObject SupplyScreen;
    public void SupplyScreenON()
    {
        SupplyScreen.gameObject.SetActive(true);
    }
    public void SupplyScreenOFF()
    {
        SupplyScreen.gameObject.SetActive(false);
    }
}
