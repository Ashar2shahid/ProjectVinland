using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using System;
using System.Linq;
using TMPro;

public class ContractCallInterface : MonoBehaviour
{
    public string method;
    public string abi;
    public string contractAddress;
    public List<serializableClass> argList = new List<serializableClass>();
    public string value = "0";

    async public void sendTransaction()
    {
        try
        {
            abi = abi.Replace("\\\"", "\"");
            string arg = convertArgsToString();
            Debug.Log(arg);
            string response = await Web3GL.SendContract(method, abi, contractAddress, arg, value);
            Debug.Log(response);
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
        };
    }

    public string convertArgsToString()
    {
        List<string> argStrings = new List<string>();
        string[][] argsArray = argList.Select(a => a.ToArray()).ToArray();
        foreach (string[] args in argsArray)
        {
            if (args.Length > 1)
            {
                argStrings.Add("[" + string.Format("\"{0}\"", string.Join("\",\"", args)) + "]");
            }
            else
            {
                argStrings.Add($"\"{string.Join(",", args)}\"");
            }
        }
        return "[" + string.Join(",", argStrings.ToArray()) + "]";
    }
}


[System.Serializable]
public class serializableClass
{
    public List<TMP_InputField> innerArgs;

    internal string[] ToArray()
    {
        return innerArgs.Select(a => a.text).ToArray();
    }
}
