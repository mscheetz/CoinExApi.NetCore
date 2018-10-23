# CoinExApi.NetCore  
.Net Core library for accessing the [CoinEx](https://www.coinex.com/account/signup?refer_code=qyg7v) Api  

This library is available on NuGet for download: https://www.nuget.org/packages/CoinExApi.NetCore  
```
PM> Install-Package CoinExApi.NetCore
```

CoinEx is a global and professional digital coin exchange service provider.  
For more information: [https://www.coinex.com/](https://www.coinex.com/account/signup?refer_code=qyg7v)
  
## Initialization:  
  
###### Non-secured endpoints only:  
```
var coinEx = new CoinExApiClient(); 
```  
  
###### Secure & non-secure endpoints:  
Before invoking secure endpoints create an API key Accounts > API.  
Make note of the Access ID and Secret Key.  
```
var coinEx = new CoinExApiClient(Access ID, Secret Key);  
```  
or create a config file:  
```
{
  "apiKey": "Access ID",
  "apiSecret": "Secret Key"
}

var coinEx = new CoinExApiClient("path-to-config");  
```

  
## Using an endpoint  
```
var pairs = await coinEx.GetMarketList();
```
or  
```
var pairs = coinEx.GetMarketList().Result;
```  

###### Non-secured endpoints:  
GetMarketList() | GetMarketListAsync() - get trading pairs  
GetTicker() | GetTickerAsync() - get ticker for a trading pair  
GetMarketDepth() | GetMarketDepthAsync() - get market depth for a trading pair  
GetTransactionData() | GetTransactionDataAsync() - get data about a transaction  
GetKLine() | GetKLineAsync() - get k-line (candlestick) data  
  
###### Secure Endpoints:  
GetBalance() | GetBalanceAsync() - get contract balance of logged in wallet  
GetWithdrawals() | GetWithdrawalsAsync() - get all withdrawals from account
CancelWithdrawal() | CancelWithdrawalAsync() - cancel a withdrawal  
LimitOrder() | LimitOrderAsync() - place a limit order  
MarketOrder() | MarketOrderAsync() - place a market order  
IOCOrder() | IOCOrderAsync() - place an immediate-or-cancel order  
GetOpenOrders() | GetOpenOrdersAsync() - get all open orders for account  
GetOrder() | GetOrderAsync() - get detail about an order
GetOrders() | GetOrdersAsync() - get completed orders  
GetUserDetails() | GetUserDetailsAsync() - get details about current account  
CancelOrder() | CancelOrderAsync() - cancel an order  
GetMiningDifficulty() | GetMiningDifficultyAsync() - get mining difficulty of exchange  

CET/ETH:  
0x3c8e741c0a2Cb4b8d5cBB1ead482CFDF87FDd66F  
BTC:  
1MGLPvTzxK9argeNRTHJ9EZ3WtGZV6nxit  
XLM:  
GA6JNJRSTBV54W3EGWDAWKPEGGD3QCXIGEHMQE2TUYXUKKTNKLYWEXVV  
