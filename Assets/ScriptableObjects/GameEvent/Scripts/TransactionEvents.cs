using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New TransactionEvents", menuName = "GameEvent/TransactionEvents")]
public class TransactionEvents : GameEvent<TransactionEvents.EventData>
{

    public enum TransactionActions
    {
       Loading,
       Pending,
       Failed,
       Finished
    }

    [System.Serializable]
    public struct EventData
    {
        public TransactionActions action; //The type of event like loading, submit etc
    }
}

