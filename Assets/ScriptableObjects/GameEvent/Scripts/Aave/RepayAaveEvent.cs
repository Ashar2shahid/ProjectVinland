using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New RepayAaveEvent", menuName = "GameEvent/RepayAaveEvent")]
public class RepayAaveEvent : GameEvent<RepayAaveEvent.EventData>
{
        public enum IntrestRateMode
    {
        Variable = 0,
        Fixed = 1
    }

    [System.Serializable]
    public struct EventData
    {
        public string asset;                // The token that you will be rapaying intrest for  
        public float amount;                // The amount of token that you will be repaying intrest
        public IntrestRateMode rateMode;    // Variable intrest rate/fixed intrest rate
    }
}
