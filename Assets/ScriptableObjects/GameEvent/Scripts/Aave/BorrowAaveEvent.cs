using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New BorrowAaveEvent", menuName = "GameEvent/BorrowAaveEvent")]
public class BorrowAaveEvent : GameEvent<BorrowAaveEvent.EventData>
{

        public enum IntrestRateMode
    {
        Variable = 0,
        Fixed = 1
    }

    [System.Serializable]
    public struct EventData
    {
        public string asset;          // The token that you will be borrowing based on your Lended amount (over collateralized)
        public float amount;          // The amount of token you will be borrowing that is limited based on your Lended amount (over collateralized)
        public IntrestRateMode mode;  // Variable intrest rate/fixed intrest rate
    }
}
