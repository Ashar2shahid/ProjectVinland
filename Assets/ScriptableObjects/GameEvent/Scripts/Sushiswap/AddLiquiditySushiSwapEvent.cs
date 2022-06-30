using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New AddLiquiditySushiSwapEvent", menuName = "GameEvent/AddLiquiditySushiSwapEvent")]
public class AddLiquiditySushiSwapEvent : GameEvent<AddLiquiditySushiSwapEvent.EventData>
{
    [System.Serializable]
    public struct EventData
    {
        public string tokenA;            // The address of Token A
        public string tokenB;            // The address of Token B
        public float amountA;            // The amount of tokenA sent to the pool.
        public float amountB;            // The amount of tokenB sent to the pool.
    }
}
