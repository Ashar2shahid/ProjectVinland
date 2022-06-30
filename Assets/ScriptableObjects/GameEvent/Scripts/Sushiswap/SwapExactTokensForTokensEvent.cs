using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Can be used for different Protocols that support swapping
[CreateAssetMenu(fileName = "New SwapExactTokensForTokensEvent", menuName = "GameEvent/SwapExactTokensForTokensEvent")]
public class SwapExactTokensForTokensEvent : GameEvent<SwapExactTokensForTokensEvent.EventData>
{
    [System.Serializable]
    public struct EventData
    {
        public float amountIn;
        public float amountOutMin;
        public string tokenIn;
        public string tokenOut;
    }
}
