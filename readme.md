#CoinKeeper Parser
Project contains two library for export data from [CoinKeeper](https://coinkeeper.me)

#### CoinKeeperApiClient
1) CoinKeeperApiClient - api client for web version of the Coinkeeper. 
 For authorize need get value of the cookie `__AUTH_cookie` on domain https://coinkeeper.me  
 The easiest way is to sniff XHR queries made by browser when log in in the web version of the Coinkeeper
#### CoinKeeperParser  
2) CoinKeeperParser - parser for the CSV file, which can be download from Android app CoinKeeper v.2 (in modern app version (v.3) this function does not exist).
[Link on GooglePlay](https://play.google.com/store/apps/details?id=com.disrapp.coinkeeper.material)
For download file you need go to the "Settings" -> "Export"

#### Sandbox
Sandbox is project with example of use.


