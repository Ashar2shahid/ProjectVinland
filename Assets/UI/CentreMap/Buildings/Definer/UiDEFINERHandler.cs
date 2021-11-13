using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using System;
using Newtonsoft.Json;

public class UiDEFINERHandler : MonoBehaviour
{
    private string input;
    private string SwapFromName;
    private string SwapFromInput;
    private string SwapToName;
    private string SwapToInput;
    private string SwapToBalance;

    private string DepositAmount;
    private string DepositAddress;
    private string WithdrawAmount;
    private string WithdrawAddress;
    private string RepayAmount;
    private string RepayAddress;

    public Text DepositBalance;
    public Text WithdrawBalance;
    public Text BorrowBalance;
    public Text RepayBalance;

    public InputField RepayAssetAddress;
    public InputField RepayAssetAmount;
    public InputField DepositAssetAddress;
    public InputField DepositAssetAmount;
    public InputField WithdrawAssetAddress;
    public InputField WithdrawAssetAmount;
    public InputField BorrowAssetAddress;
    public InputField BorrowAssetAmount;

    public GameObject DefinerUI;
    private Token token = new Token();
    string contract;
    string abi;
    Dictionary<string, float> LTVs;
    IDictionary<string, string>  addressesToAssets;
    IDictionary<string, string>  addressesToIAssets;
    IDictionary<string, string>  addressesToIaddresses;
    public Text UserInfoData;
    // private Token token;
    // Start is called before the first frame update
    void Start()
    {
        token.account = token.GetAccount();
        abi = "[{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"previousAdmin\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"newAdmin\",\"type\":\"address\"}],\"name\":\"AdminChanged\",\"payable\":false,\"type\":\"event\"},{\"constant\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"implementation\",\"type\":\"address\"}],\"name\":\"Upgraded\",\"payable\":false,\"type\":\"event\"},{\"constant\":false,\"payable\":true,\"stateMutability\":\"payable\",\"type\":\"fallback\"},{\"constant\":false,\"inputs\":[],\"name\":\"admin\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"newAdmin\",\"type\":\"address\"}],\"name\":\"changeAdmin\",\"outputs\":[],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[],\"name\":\"implementation\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"_logic\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"_admin\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"bytes\",\"name\":\"_data\",\"type\":\"bytes\"}],\"name\":\"initialize\",\"outputs\":[],\"payable\":true,\"stateMutability\":\"payable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"_logic\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"bytes\",\"name\":\"_data\",\"type\":\"bytes\"}],\"name\":\"initialize\",\"outputs\":[],\"payable\":true,\"stateMutability\":\"payable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"newImplementation\",\"type\":\"address\"}],\"name\":\"upgradeTo\",\"outputs\":[],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"newImplementation\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"bytes\",\"name\":\"data\",\"type\":\"bytes\"}],\"name\":\"upgradeToAndCall\",\"outputs\":[],\"payable\":true,\"stateMutability\":\"payable\",\"type\":\"function\"}]";
        
        // LTVs = new Dictionary<string, float>()
        // {
        //     {"USDC", 0.8f},
        //     {"DAI", 0.75f},
        //     {"WETH", 0.8f},
        //     {"WBTC", 0.7f},
        //     {"WMATIC", 0.7f}, //assuming
        // };
        LTVs = new Dictionary<string, float>()
        {
            {"0x1a13f4ca1d028320a707d99520abfefca3998b7f", 0.8f},
            {"0x1d2a0e5ec8e5bbdca5cb219e649b565d8e5c3360", 0.75f},
            {"0x5c2ed810328349100a66b82b78a1791b101c9d61", 0.8f},
            {"0x28424507fefb6f7f8e9d3860f56504e4e5f5f390", 0.7f},
            {"0x60d55f02a771d515e077c9c2403a1ef324885cec" , 0.8f},
            {"0x27f8d03b3a2196956ed754badc28d73be8830a6e", 0.8f}//assuming
        }; 

        addressesToAssets = new Dictionary<string, string>()
        {
            {"USDC", "0x2791bca1f2de4661ed88a30c99a7a9449aa84174"},
            {"DEFINER", "0xd6df932a45c0f255f85145f286ea0b292b21c90b"},// Wrong Address renamed from AAVE
            {"WBTC", "0x1bfd67037b42cf73acf2047067bd4f2c47d9bfd6"},
            {"WETH", "0x7ceb23fd6bc0add59e62ac25578270cff1b9f619"},
            {"DAI", "0x8f3cf7ad23cd3cadbd9735aff958023239c6a063"},
            {"USDT", "0xc2132d05d31c914a87c6611c10748aeb04b58e8f"},
        };
        addressesToIAssets = new Dictionary<string, string>()
        {
            {"maUSDC", "0x1a13f4ca1d028320a707d99520abfefca3998b7f"},
            {"maDEFINER", "0x1d2a0e5ec8e5bbdca5cb219e649b565d8e5c3360"},
            {"maWBTC", "0x5c2ed810328349100a66b82b78a1791b101c9d61"},
            {"maWETH", "0x28424507fefb6f7f8e9d3860f56504e4e5f5f390"},
            {"maDAI", "0x27f8d03b3a2196956ed754badc28d73be8830a6e"},
            {"maUSDT", "0x60d55f02a771d515e077c9c2403a1ef324885cec"}
        };
        addressesToIaddresses = new Dictionary<string, string>()
        {
            {"0x2791bca1f2de4661ed88a30c99a7a9449aa84174", "0x1a13f4ca1d028320a707d99520abfefca3998b7f"},
            {"0xd6df932a45c0f255f85145f286ea0b292b21c90b", "0x1d2a0e5ec8e5bbdca5cb219e649b565d8e5c3360"},
            {"0x1bfd67037b42cf73acf2047067bd4f2c47d9bfd6", "0x5c2ed810328349100a66b82b78a1791b101c9d61"},
            {"0x7ceb23fd6bc0add59e62ac25578270cff1b9f619", "0x28424507fefb6f7f8e9d3860f56504e4e5f5f390"},
            {"0x8f3cf7ad23cd3cadbd9735aff958023239c6a063", "0x27f8d03b3a2196956ed754badc28d73be8830a6e"},
            {"0xc2132d05d31c914a87c6611c10748aeb04b58e8f", "0x60d55f02a771d515e077c9c2403a1ef324885cec"},
        };
        // address of contract || token address
        contract = "0xF3c87c005B04a07Dc014e1245f4Cff7A77b6697b";

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.P)){
            ToggleDefinerUI();
        }
    }

    public void ReadDepositAmountFromInput(string s){
        DepositAmount = s;
        Debug.Log("Deposit amount" + DepositAmount);
    }
    
    public void ReadDepositFromInput(string s){
        DepositAddress = s;
        Debug.Log("Deposit Input" + DepositAddress);
        // UIValueHandler();
        // BigInteger balanceOf = await ERC20.BalanceOf(token.chain, token.network, DepositAddress , token.account);
        // BigInteger balanceOfWithdraw = await ERC20.BalanceOf(token.chain, token.network, addressesToIaddresses[DepositAddress] , token.account);
        // string symbol = await ERC20.Symbol(token.chain, token.network, DepositAddress);
        // string symbolWithdraw = await ERC20.Symbol(token.chain, token.network, addressesToIaddresses[DepositAddress]);
        // DepositAssetAddress.text = symbol;
        // DepositBalance.text = balanceOf.ToString();
        // WithdrawAssetAddress.text = symbolWithdraw;
        // WithdrawBalance.text = balanceOfWithdraw.ToString();
    }
    public void ReadWithdrawAmountFromInput(string s){
        WithdrawAmount = s;
        Debug.Log("Withdraw amount" + WithdrawAmount);    
    }
    async public void ReadWithdrawFromInput(string s){
        WithdrawAddress = s;
        Debug.Log("Withdraw Input" + WithdrawAddress);
        BigInteger balanceOf = await ERC20.BalanceOf(token.chain, token.network, WithdrawAddress , token.account);
        string symbol = await ERC20.Symbol(token.chain, token.network, WithdrawAddress);
        WithdrawAssetAddress.text = symbol;
        WithdrawBalance.text = balanceOf.ToString();
    }
    public void ReadRepayAmountFromInput(string s){
        RepayAmount = s;
        Debug.Log("Repay amount" + RepayAmount);
    }
    async public void ReadRepayFromInput(string s){
        RepayAddress = s;
        Debug.Log("Repay Input" + RepayAddress);
        BigInteger balanceOf = await ERC20.BalanceOf(token.chain, token.network, RepayAddress , token.account);
        string symbol = await ERC20.Symbol(token.chain, token.network, RepayAddress);
        RepayAssetAddress.text = symbol;
        balanceOf = (BigInteger)((float)balanceOf * LTVs[WithdrawAddress]);
        RepayBalance.text = balanceOf.ToString();
    }
    public void Deposit( ){
        DepositCall(DepositAddress, DepositAmount);
    }
    public void Withdraw( ){
        WithdrawCall(WithdrawAddress, WithdrawAmount);
    }
    public void Repay( ){
        RepayCall(RepayAddress, RepayAmount);
    }
    async public void RepayCall(string AssetAddress, string AssetAmount){
        // insert deposit function
        string method = "repay";
        Debug.Log(AssetAmount +" " + AssetAddress);
        BigInteger AssetAmount2 = BigInteger.Parse(AssetAmount);

        Debug.Log(AssetAmount2);

        string args = $"[\"{AssetAddress}\", \"{AssetAmount2}\" , \"1\" , \"0x4d67aA3D291a17538888D1BdB47aA6D12C52cc71\"]";
        
        Debug.Log(args);
        // connects to user's browser wallet to call a transaction
        string value = "0";
        // gas limit OPTIONAL
        string gas = "21000";
        // connects to user's browser wallet (metamask) to send a transaction
        try {
        string response = await Web3GL.SendContract(method, abi, contract, args, value);
        Debug.Log(response); 
        } catch (Exception e) {
        Debug.LogException(e, this);
        };
    }
    async public void DepositCall(string AssetAddress, string AssetAmount){
        // insert deposit function
        string method = "deposit";
        Debug.Log(AssetAmount +" " + AssetAddress);
        BigInteger AssetAmount2 = BigInteger.Parse(AssetAmount);

        Debug.Log(AssetAmount2);

        string args = $"[ \"0\",\"{AssetAddress}\", \"{AssetAmount}\"]";
        
        Debug.Log(args);
        // connects to user's browser wallet to call a transaction
        string value = "0";
        // gas limit OPTIONAL
        string gas = "21000";
        // connects to user's browser wallet (metamask) to send a transaction
        try {
        string response = await Web3GL.SendContract(method, abi, contract, args, value);
        Debug.Log(response); 
        } catch (Exception e) {
        Debug.LogException(e, this);
        };
    }
    async public void WithdrawCall(string AssetAddress, string AssetAmount){
        // insert deposit function
        string method = "withdraw";
        
        BigInteger AssetAmount2 = BigInteger.Parse(AssetAmount);

        string args = $"[\"{AssetAddress}\", \"{AssetAmount2}\" , \"0x4d67aA3D291a17538888D1BdB47aA6D12C52cc71\"]";
        
        Debug.Log(args);
        // connects to user's browser wallet to call a transaction
        string value = "0";
        // gas limit OPTIONAL
        string gas = "21000";
        // connects to user's browser wallet (metamask) to send a transaction
        try {
        string response = await Web3GL.SendContract(method, abi, contract, args, value);
        Debug.Log(response); 
        } catch (Exception e) {
        Debug.LogException(e, this);
        };
    }
    async public void BorrowAgainstCollateral(){
        // borrowing dai vs eth 0.75
        string method = "borrow";
        string asset = addressesToAssets["WETH"];
        int interestRateMode = 2;
        //empty [] for args 
        // to do complete 
        // try {
        //     string response = await Web3GL.SendContract(method, abi, contract, args, value);
        //     Debug.Log(response); 
        //     } catch (Exception e) {
        //     Debug.LogException(e, this);
        // };
        // try {
        //     UserInfoData.text = await Web3GL("polygon", "mainnet", contract, abi, method, args);
        //     Debug.Log(UserInfoData);
        //     Debug.Log(JsonConvert.SerializeObject(UserInfoData) );         
        //     } catch (Exception e) {
        //     Debug.LogException(e, this);
        // }; 
    }

    async public void BorrowAmount(){
        string method = "getUserAccountData";
        string[] obj = { token.account };
        string args = JsonConvert.SerializeObject(obj);
        
        try {
            string userData= await EVM.Call(token.chain, token.network, contract, abi, method, args);
            Debug.Log(userData);
            Debug.Log(JsonConvert.SerializeObject(userData) ); 
            JsonConvert.SerializeObject(userData);
            // BorrowBalance.text = ((float)userData["totalCollateralETH"]).ToString();
            // RepayBalance.text = ((float)userData["totalDebtETH"]).ToString();

            } catch (Exception e) {
            Debug.LogException(e, this);
        }; 
    }
    async public void UIValueHandler(){
        BigInteger balanceOf = await ERC20.BalanceOf(token.chain, token.network, DepositAddress , token.account, token.RPC);
        BigInteger balanceOfWithdraw = await ERC20.BalanceOf(token.chain, token.network, addressesToIaddresses[DepositAddress] , token.account, token.RPC);
        string symbol = await ERC20.Symbol(token.chain, token.network, DepositAddress, token.RPC);
        string symbolWithdraw = await ERC20.Symbol(token.chain, token.network, addressesToIaddresses[DepositAddress], token.RPC);
        DepositAssetAddress.text = symbol;
        DepositBalance.text = balanceOf.ToString();
        WithdrawAssetAddress.text = symbolWithdraw;
        WithdrawBalance.text = balanceOfWithdraw.ToString();
        // BorrowAmount();
        // BorrowAssetAddress.text = symbol;
        // BorrowBalance.text = new BigInteger((float)(balanceOfWithdraw)*(LTVs[addressesToIaddresses[DepositAddress]])).ToString();

    }

    public void ToggleDefinerUI(){
        if(DefinerUI.activeSelf == true){
            DefinerUI.SetActive(false);  
        }else{
            DefinerUI.SetActive(true);
        }
    }
}
//
//                
//
//
//
//  string args = $"[\"{AssetAddress}\", \"{AssetAmount2}\" , \"2\" , \"0\"]";
//
//
//
//
//
//
//
