using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandlerUNIV3Swap : MonoBehaviour
{
    // Start is called before the first frame update

    public Text tokenIn;
    public Text tokenOut;
    public Text fee;
    public Text recipient;
    public Text deadline;
    public Text amountIn;
    public Text amountOutMinimum;
    public Text sqrtPriceLimitX96;

    private Token token = new Token();

    void Start()
    {
        recipient.text = token.GetAccount();
        deadline.text = (DateTimeOffset.Now.ToUnixTimeSeconds() + 10000L).ToString();
    }

    public void readTokenIn(string s)
    {
        tokenIn.text = s;
    }

    public void readTokenOut(string s)
    {
        tokenOut.text = s;
    }

    public void readFee(string s)
    {
        fee.text = s;
    }

    public void readRecipient(string s)
    {
        recipient.text = s;
    }

    public void readDeadline(string s)
    {
        deadline.text = s;
    }

    public void readAmountIn(string s)
    {
        amountIn.text = s;
    }

    public void readAmountOutMinimum(string s)
    {
        amountOutMinimum.text = s;
    }

    public void readSqrtPriceLimitX96(string s)
    {
        sqrtPriceLimitX96.text = s;
    }
}
