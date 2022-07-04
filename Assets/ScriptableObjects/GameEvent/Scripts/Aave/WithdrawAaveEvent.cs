using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New WithdrawAaveEvent", menuName = "GameEvent/WithdrawAaveEvent")]
public class WithdrawAaveEvent : GameEvent<WithdrawAaveEvent.EventData>
{
    [System.Serializable]
    public struct EventData
    {
        public string asset;    // The token that you will be Withdrawing that is already lended
        public float amount;    // The amount you will be Withdrawing that is already lended
    }
}
