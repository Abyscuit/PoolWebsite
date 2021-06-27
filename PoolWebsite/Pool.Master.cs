using Nethereum.Signer;
using Nethereum.Web3.Accounts;
using PoolWebsite.Metamask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoolWebsite
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public static Account account, account2;
        protected void Page_Load(object sender, EventArgs e)
        {
            account = new Account("0x4b7e52cc4a131195f08ad7ba0b8e9172ab418813701a59e949136b40adba3f94", Chain.MainNet);
            account2 = new Account("0x6959c5d894aa84520ff4657a5cf2b31a1e3a8d7980f78d2cd6035555a95948dc", Chain.MainNet);
        }
    }
}