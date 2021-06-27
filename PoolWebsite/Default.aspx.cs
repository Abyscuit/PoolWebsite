using Nethereum.Signer;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Numerics;

namespace PoolWebsite
{
    public partial class _Default : Page
    {
        public static Web3 web3 = new Web3("https://data-seed-prebsc-1-s1.binance.org:8545");
        public static decimal bal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            var balance = web3.Eth.GetBalance.SendRequestAsync("0x41A50eF9579aA9E21C48DCC707BB14e30C9c60fA");
            bal = Web3.Convert.FromWei(balance.Result.Value);
        }
    }
}