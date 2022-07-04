using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New LendAaveEvent", menuName = "GameEvent/LendAaveEvent")]
public class LendAaveEvent : GameEvent<LendAaveEvent.EventData>
{
    [System.Serializable]
    public struct EventData
    {
        public string asset;   // The token that you will be Lending
        public float amount;   // The amount of token you will be Lending
    }
}
