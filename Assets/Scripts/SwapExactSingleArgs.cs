using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SwapExactSingleArgs : MonoBehaviour
{
    public TMP_InputField recipient;
    public TMP_InputField deadline;

    // Start is called before the first frame update
    void Start()
    {
      string account = PlayerPrefs.GetString("Account");
      recipient.text = account;
    }

    // Update is called once per frame
    void Update()
    {
        string account = PlayerPrefs.GetString("Account");
        recipient.text = account;
        deadline.text = $"{(DateTimeOffset.Now.ToUnixTimeSeconds() + 10000L)}";
    }
}
