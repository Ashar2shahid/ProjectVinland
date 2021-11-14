using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunNFTMinter : MonoBehaviour
{
    private Token token = new Token();
    public void MintGunNFT(){
        MintGunNFTCall();
    }
    async public void MintGunNFTCall()
    {
        // smart contract method to call
        string method = "mint";
        // abi in json format
        string abi = "[{\"inputs\":[{\"internalType\":\"bytes4\",\"name\":\"interfaceId\",\"type\":\"bytes4\"}],\"name\":\"supportsInterface\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";
        
        string contract = "0x5d1f7e7f340174f1466898b519f321df248a2053";
        // array of arguments for contract
        string uri = "https://game.example/item-id-8u5h2m.json";
        string args = $"[\"{token.account}\", \"{uri}\"]";
        // value in wei
        string value = "0";
        // connects to user's browser wallet (metamask) to send a transaction
        try {
            string response = await Web3GL.SendContract(method, abi, contract, args, value);
            Debug.Log(response);
        } catch (Exception e) {
            Debug.LogException(e, this);
        }
    }
}