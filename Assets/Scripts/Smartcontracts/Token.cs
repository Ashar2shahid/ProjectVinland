using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//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 //gituhb waala code
public class Token : MonoBehaviour
{
    public string chain = "ethereum";
    public string network = "ropsten";
    public string account = "";

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
    int blockNumber = await EVM.BlockNumber(chain, network);
    Debug.Log(blockNumber);
    }
    async public void GetBalanceOfChain(string chain,string network,string account){
    string balance = await EVM.BalanceOf(chain, network, account);
    Debug.Log("balance");
    Debug.Log(balance);
    }
    async public void GetBalanceOfToken(string chain,string network,string account , string contract){
    string balance = await EVM.BalanceOf(chain, network, contract, account);
    Debug.Log("balance");
    Debug.Log(balance);
    // return balance;
    }
    public string GetAccount(){
        // account = PlayerPrefs.GetString("Account");
        account = "0x4d67aA3D291a17538888D1BdB47aA6D12C52cc71";
        print(account);
        return account;
        // return account;
    }
}
