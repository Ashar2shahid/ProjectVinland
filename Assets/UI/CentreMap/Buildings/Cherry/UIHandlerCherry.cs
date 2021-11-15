using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;
using System;
public class UIHandlerCherry : MonoBehaviour
{
    private string input;
    private string SwapFromName;
    private string SwapFromInput;
    private string SwapToName;
    private string SwapToInput;
    private string SwapToBalance;
    private string SwapFromBalance;
    public Text SwapToBalText;
    public Text SwapFromBalText;
    public InputField SwapToNameInp;
    public InputField SwapFromNameInp;
    public GameObject ApproveButton;
    public GameObject SwapButton;
    public GameObject CherryUI;
    private Token token = new Token();
    string contract = "0x865bfde337C8aFBffF144Ff4C29f9404EBb22b15";
    // private Token token;
    // Start is called before the first frame update
    void Start()
    {
        token.account = token.GetAccount();
        // int networkId = Web3GL.Network();
        // Debug.Log("Network ID " + networkId);

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.O)){
            ToggleCherryUI();
        }
    }
    async public void ReadSwapfromName(string s){
        SwapFromName = s;
        Debug.Log("SwapFromName " + SwapFromName);
        Debug.Log(token.chain + " " + token.network + " " + SwapFromName + " " + token.account + " " + contract );
        BigInteger allowance = await ERC20.Allowance(token.chain, token.network, SwapFromName, token.account,contract,token.RPC);
        Debug.Log("allowance" + allowance);
        if(allowance == 0){
            ApproveButton.SetActive(true);
            SwapButton.SetActive(false);
        }else{
            ApproveButton.SetActive(false);
            SwapButton.SetActive(true);
        }
        // BigInteger balanceOf = await ERC20.BalanceOf(token.chain, token.network, SwapFromName, token.account);
        // Debug.Log(balanceOf);
        // BigInteger decimals = await ERC20.Decimals(token.chain, token.network, SwapFromName);

        // string symbol = await ERC20.Symbol(token.chain, token.network, SwapFromName);
        // Debug.Log(symbol);
        // SwapFromNameInp.text = symbol;
        // SwapFromBalText.text = balanceOf.ToString();
    }
   public void ReadSwapFromInput(string s){
        SwapFromInput = s;
        Debug.Log("SwapFromInput " + SwapFromInput);
    }
    async public void ReadSwapToName(string s){
        SwapToName= s;
        Debug.Log("SwapToName " + SwapToName);
        // SwapToBalText.text = CallBalanceOf(SwapToName);
        BigInteger balanceOf = await ERC20.BalanceOf(token.chain, token.network, SwapToName, token.account, token.RPC);
        // Debug.Log(balanceOf);
        // BigInteger decimals = await ERC20.Decimals(token.chain, token.network, SwapToName);
        // Debug.Log("Decimals " + decimals);
        // Debug.Log("Decimals " + BigInteger.Pow(10 ,((int)decimals)));
        // float balanceOfF= ((float)BigInteger.Divide(balanceOf , BigInteger.Pow(10 ,((int)decimals))));
        // Debug.Log(balanceOfF);
        // string symbol = await ERC20.Symbol(token.chain, token.network, SwapToName);
        // Debug.Log(symbol);
        // SwapToNameInp.text = symbol;
        // SwapToBalText.text = balanceOf.ToString();
    }
    public void ReadSwapToInput(string s){
        SwapToInput = s;
        Debug.Log("SwapToInput " + SwapToInput);
    }
    public void Swap( ){
        Debug.Log( "SwapFromName " + SwapFromName + " SwapFromInput " + SwapFromInput + " SwapToName " + SwapToName + " SwapToInput " + SwapToInput );
        
        SwapCall(SwapFromName,SwapFromInput,SwapToName, SwapToInput);
        
    }
    async public void SwapCall(string SwapFromName,string SwapFromInput,string SwapToName, string SwapToInput){
        // insert swap function
        ////
        BigInteger allowance = await ERC20.Allowance(token.chain, token.network, SwapFromName, token.account,contract,token.RPC);
        Debug.Log("allowance" + allowance);
        if(allowance == 0){
            ApproveButton.SetActive(true);
            SwapButton.SetActive(false);
        }else{
            ApproveButton.SetActive(false);
            SwapButton.SetActive(true);
        }
        //////
        string method = "swapExactTokensForTokens";
        string abi = "[{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"_factory\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"_WETH\",\"type\":\"address\"}],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"constructor\"},{\"constant\":false,\"inputs\":[],\"name\":\"WETH\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[],\"name\":\"factory\",\"outputs\":[{\"internalType\":\"address\",\"name\":\"\",\"type\":\"address\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"constant\":false,\"payable\":false,\"stateMutability\":\"payable\",\"type\":\"receive\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"tokenA\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"tokenB\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountADesired\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountBDesired\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountAMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountBMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"}],\"name\":\"addLiquidity\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"amountA\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"amountB\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"liquidity\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"token\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountTokenDesired\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountTokenMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountETHMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"}],\"name\":\"addLiquidityETH\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"amountToken\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"amountETH\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"liquidity\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"payable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"tokenA\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"tokenB\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"liquidity\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountAMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountBMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"}],\"name\":\"removeLiquidity\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"amountA\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"amountB\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"token\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"liquidity\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountTokenMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountETHMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"}],\"name\":\"removeLiquidityETH\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"amountToken\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"amountETH\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"tokenA\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"tokenB\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"liquidity\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountAMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountBMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"bool\",\"name\":\"approveMax\",\"type\":\"bool\"},{\"indexed\":false,\"internalType\":\"uint8\",\"name\":\"v\",\"type\":\"uint8\"},{\"indexed\":false,\"internalType\":\"bytes32\",\"name\":\"r\",\"type\":\"bytes32\"},{\"indexed\":false,\"internalType\":\"bytes32\",\"name\":\"s\",\"type\":\"bytes32\"}],\"name\":\"removeLiquidityWithPermit\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"amountA\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"amountB\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"token\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"liquidity\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountTokenMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountETHMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"bool\",\"name\":\"approveMax\",\"type\":\"bool\"},{\"indexed\":false,\"internalType\":\"uint8\",\"name\":\"v\",\"type\":\"uint8\"},{\"indexed\":false,\"internalType\":\"bytes32\",\"name\":\"r\",\"type\":\"bytes32\"},{\"indexed\":false,\"internalType\":\"bytes32\",\"name\":\"s\",\"type\":\"bytes32\"}],\"name\":\"removeLiquidityETHWithPermit\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"amountToken\",\"type\":\"uint256\"},{\"internalType\":\"uint256\",\"name\":\"amountETH\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"token\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"liquidity\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountTokenMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountETHMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"}],\"name\":\"removeLiquidityETHSupportingFeeOnTransferTokens\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"amountETH\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"address\",\"name\":\"token\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"liquidity\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountTokenMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountETHMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"bool\",\"name\":\"approveMax\",\"type\":\"bool\"},{\"indexed\":false,\"internalType\":\"uint8\",\"name\":\"v\",\"type\":\"uint8\"},{\"indexed\":false,\"internalType\":\"bytes32\",\"name\":\"r\",\"type\":\"bytes32\"},{\"indexed\":false,\"internalType\":\"bytes32\",\"name\":\"s\",\"type\":\"bytes32\"}],\"name\":\"removeLiquidityETHWithPermitSupportingFeeOnTransferTokens\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"amountETH\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountIn\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOutMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address[]\",\"name\":\"path\",\"type\":\"address[]\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"}],\"name\":\"swapExactTokensForTokens\",\"outputs\":[{\"internalType\":\"uint256[]\",\"name\":\"amounts\",\"type\":\"uint256[]\"}],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOut\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountInMax\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address[]\",\"name\":\"path\",\"type\":\"address[]\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"}],\"name\":\"swapTokensForExactTokens\",\"outputs\":[{\"internalType\":\"uint256[]\",\"name\":\"amounts\",\"type\":\"uint256[]\"}],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOutMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address[]\",\"name\":\"path\",\"type\":\"address[]\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"}],\"name\":\"swapExactETHForTokens\",\"outputs\":[{\"internalType\":\"uint256[]\",\"name\":\"amounts\",\"type\":\"uint256[]\"}],\"payable\":false,\"stateMutability\":\"payable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOut\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountInMax\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address[]\",\"name\":\"path\",\"type\":\"address[]\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"}],\"name\":\"swapTokensForExactETH\",\"outputs\":[{\"internalType\":\"uint256[]\",\"name\":\"amounts\",\"type\":\"uint256[]\"}],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountIn\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOutMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address[]\",\"name\":\"path\",\"type\":\"address[]\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"}],\"name\":\"swapExactTokensForETH\",\"outputs\":[{\"internalType\":\"uint256[]\",\"name\":\"amounts\",\"type\":\"uint256[]\"}],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOut\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address[]\",\"name\":\"path\",\"type\":\"address[]\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"}],\"name\":\"swapETHForExactTokens\",\"outputs\":[{\"internalType\":\"uint256[]\",\"name\":\"amounts\",\"type\":\"uint256[]\"}],\"payable\":false,\"stateMutability\":\"payable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountIn\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOutMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address[]\",\"name\":\"path\",\"type\":\"address[]\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"}],\"name\":\"swapExactTokensForTokensSupportingFeeOnTransferTokens\",\"outputs\":[],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOutMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address[]\",\"name\":\"path\",\"type\":\"address[]\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"}],\"name\":\"swapExactETHForTokensSupportingFeeOnTransferTokens\",\"outputs\":[],\"payable\":false,\"stateMutability\":\"payable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountIn\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOutMin\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address[]\",\"name\":\"path\",\"type\":\"address[]\"},{\"indexed\":false,\"internalType\":\"address\",\"name\":\"to\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"deadline\",\"type\":\"uint256\"}],\"name\":\"swapExactTokensForETHSupportingFeeOnTransferTokens\",\"outputs\":[],\"payable\":false,\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountA\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"reserveA\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"reserveB\",\"type\":\"uint256\"}],\"name\":\"quote\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"amountB\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"pure\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountIn\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"reserveIn\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"reserveOut\",\"type\":\"uint256\"}],\"name\":\"getAmountOut\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"amountOut\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"pure\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOut\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"reserveIn\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"reserveOut\",\"type\":\"uint256\"}],\"name\":\"getAmountIn\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"amountIn\",\"type\":\"uint256\"}],\"payable\":false,\"stateMutability\":\"pure\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountIn\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address[]\",\"name\":\"path\",\"type\":\"address[]\"}],\"name\":\"getAmountsOut\",\"outputs\":[{\"internalType\":\"uint256[]\",\"name\":\"amounts\",\"type\":\"uint256[]\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"},{\"constant\":false,\"inputs\":[{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"amountOut\",\"type\":\"uint256\"},{\"indexed\":false,\"internalType\":\"address[]\",\"name\":\"path\",\"type\":\"address[]\"}],\"name\":\"getAmountsIn\",\"outputs\":[{\"internalType\":\"uint256[]\",\"name\":\"amounts\",\"type\":\"uint256[]\"}],\"payable\":false,\"stateMutability\":\"view\",\"type\":\"function\"}]";
        // address of contract || token address
        
        // array of arguments for contract: "[\"1\", \"hello\"]"
        // string args = $"[\"1\", \"0\" ,[\"0x0d500b1d8e8ef31e21c99d1db9a6444d3adf1270\",\"0x8f3cf7ad23cd3cadbd9735aff958023239c6a063\"],\"{token.account}\",\"{1632091502}\"]";
        string args = $"[\"{SwapFromInput}\", \"0\" , [\"{SwapFromName}\",\"{SwapToName}\"] , \"{token.account}\" , \"{DateTimeOffset.Now.ToUnixTimeSeconds() + 10000L}\"]";
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
    public void ToggleCherryUI(){
        if(CherryUI.activeSelf == true){
            CherryUI.SetActive(false);  
        }else{
            CherryUI.SetActive(true);
        }
    }
    public void Approve(){
        BigInteger value = BigInteger.Pow(10, 30);
        Debug.Log( "contract " + contract +"value " + value  );
        ApproveCall(contract, value);  
    }
    async public void ApproveCall(string spenderContract,BigInteger limitValue){
        // insert swap function
        string method = "approve";
        string abi = ERC20.abi;
        // address of contract || token address
        string contract = SwapFromName;
        string args = $"[\"{spenderContract}\" , \"{limitValue}\"]";
        Debug.Log(args);
        // connects to user's browser wallet to call a transaction
        string value = "0";
        // gas limit OPTIONAL
        string gas = "21000";
        // connects to user's browser wallet (metamask) to send a transaction
        try {
        string response = await Web3GL.SendContract(method, abi, contract, args, value);
        ApproveButton.SetActive(false);
        SwapButton.SetActive(true);
        Debug.Log(response); 
        } catch (Exception e) {
        Debug.LogException(e, this);
        };
    }

}
