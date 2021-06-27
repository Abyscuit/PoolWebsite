using Nethereum.Web3;
using Nethereum.Signer;
using Nethereum.Web3.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PoolWebsite
{
    public partial class Pools : System.Web.UI.Page
    {
        public static Random random = new Random();
        public struct Pool
        {
            public string Name, Asset, ImagePath;
            public decimal TotalSupply;
            public float APR;
            public DateTime StartTime;

            public Pool(string name, string asset, string imagePath)
            {
                Name = name;
                Asset = asset;
                TotalSupply = (decimal)random.NextDouble() * 999999999; // Random value for now
                APR = random.Next(100, 8000) / 10000f; // Random value for now
                StartTime = DateTime.Now.AddDays(400 - random.Next(0, 800)); // Random date for now
                ImagePath = imagePath;
            }

            public bool Compare(Pool otherPool)
            {
                if (otherPool.Name == Name) return true;
                return false;
            }
        }

        public static List<Pool> POOL_LIST = new List<Pool>();

        /* --------------------------- *
         * Proof of concept variables. *
         * Can be deleted after demo.  *
         * --------------------------- */

        // Variable that prevents the page from injecting 
        // the table data more than once upon refreshes
        public static int val = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            random.Next(); random.Next(); random.Next();

            CreatePools();
            PopulateTable();
            
        }

        protected void CreatePools()
        {
            string path = "assets/img/avatars";
            Pool USD_POOL = new Pool("US Dollar Pool", "USD", $"{path}/dollar_sign_PNG21539.png"); POOL_LIST.Add(USD_POOL);
            Pool BTC_POOL = new Pool("Bitcoin Pool", "BTC", $"{path}/bitcoin.png"); POOL_LIST.Add(BTC_POOL);
            Pool ETH_POOL = new Pool("Ethereum Pool", "ETH", $"{path}/ethereum.png"); POOL_LIST.Add(ETH_POOL);
            Pool LTC_POOL = new Pool("Litecoin Pool", "LTC", $"{path}/litecoin.png"); POOL_LIST.Add(LTC_POOL);
            Pool USDT_POOL = new Pool("Tether Pool", "USDT", $"{path}/Tether-logo.png"); POOL_LIST.Add(USDT_POOL);
            Pool BNB_POOL = new Pool("Binance Pool", "BNB", $"{path}/binance-coin-logo.png"); POOL_LIST.Add(BNB_POOL);
            Pool ADA_POOL = new Pool("Cardano Pool", "ADA", $"{path}/cardano.png"); POOL_LIST.Add(ADA_POOL);
            Pool ATOM_POOL = new Pool("Cosmos Pool", "ATOM", $"{path}/cosmos_hub.png"); POOL_LIST.Add(ATOM_POOL);
            Pool VET_POOL = new Pool("VeChain Pool", "VET", $"{path}/VeChain-Logo-768x725.png"); POOL_LIST.Add(VET_POOL);
            Pool _1INCH_POOL = new Pool("1inch Pool", "1INCH", $"{path}/1inch-token.png"); POOL_LIST.Add(_1INCH_POOL);
        }

        protected void PopulateTable()
        {
            // Idk why val makes it not inject the table data 
            // more than once upon refresh
            for (int i = 0; val < POOL_LIST.Count; i++)
            {
                // Create the row and cells for the table

                TableRow row = new TableRow();
                TableCell nameCell = new TableCell();
                // Image control doesnt work with the text control
                nameCell.Text = $"<img class=\"rounded-circle me-2\" width=\"30\" height=\"30\" src=\"{POOL_LIST[i].ImagePath}\">{POOL_LIST[i].Name}";
                row.Controls.Add(nameCell); 

                TableCell assetCell = new TableCell();
                assetCell.Text = POOL_LIST[i].Asset;
                row.Controls.Add(assetCell); 

                TableCell supplyCell = new TableCell();
                supplyCell.Text = string.Format("{0:N2}", POOL_LIST[i].TotalSupply);
                row.Controls.Add(supplyCell);

                TableCell aprCell = new TableCell();
                aprCell.Text = string.Format("{0:P}", POOL_LIST[i].APR);
                row.Controls.Add(aprCell);

                TableCell startTimeCell = new TableCell();
                startTimeCell.Text = POOL_LIST[i].StartTime.ToString("d");
                row.Controls.Add(startTimeCell);

                TableCell walletCell = new TableCell();
                walletCell.Text = string.Format("{0:N2}", random.NextDouble() * 999999f);
                row.Controls.Add(walletCell);

                TableCell btnCell = new TableCell();
                Button supplyButton = new Button()
                {
                    CssClass = "btn btn-primary",
                    Text = "Supply",
                    ID = $"SUPPLY_{POOL_LIST[i].Asset}"
                };
                supplyButton.Click += SupplyButtonClick;
                btnCell.Controls.Add(supplyButton);
                row.Controls.Add(btnCell); 

                PlaceHolder1.Controls.Add(row); // Add row to the table

                val++;
            }
        }

        public void SupplyPool()
        {
            Transaction transaction = new Transaction(Site1.account2.Address, new BigInteger(100000000000000), Site1.account.NonceService.GetNextNonceAsync().Result);
            Response.Write(transaction.Nonce);
            Response.Write(transaction.ToString());
        }

        public void SupplyButtonClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (!btn.ID.Contains("SUPPLY")) return;
            string asset = btn.ID.Split('_')[1];
            Response.Write($"<script>alert('Supplying {asset}');</script>");

            /* Create transaction to supply the pool.*
             * Do a test run to supply on BNB until  *
             * I figure out how to supply the tokens */


        }
    }
}