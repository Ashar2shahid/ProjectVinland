using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class Token : MonoBehaviour
{
    public string chain = "OKEx";
    public string network = "mainnet";
    public string account = "";
    public string RPC = "https://exchainrpc.okex.org";

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    async public void GetBlockNumber(string chain,string network){
    Debug.Log("block number");
    int blockNumber = await EVM.BlockNumber(chain, network, RPC);
    Debug.Log(blockNumber);
    }
    async public void GetBalanceOfChain(string chain,string network,string account){
    string balance = await EVM.BalanceOf(chain, network, account, RPC);
    Debug.Log("balance");
    Debug.Log(balance);
    }
    async public void GetBalanceOfToken(string chain,string network,string account , string contract){
    BigInteger balance = await ERC20.BalanceOf(chain, network, contract, account, RPC);
    Debug.Log("balance");
    Debug.Log(balance);
    // return balance;
    }
    public string GetAccount(){
        account = PlayerPrefs.GetString("Account");
        // account = "0x4f7116a3B69b14480b0C0890d63bd4B3d0984EE6";
        print(account);
        return account;
        // return account;
    }
}
