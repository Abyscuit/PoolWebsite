using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PoolWebsite.Metamask
{
    public interface IEthereumHostProvider
    {
        string Name { get; }

        bool Available { get; }
        string SelectedAccount { get; }
        int SelectedNetwork { get; }
        bool Enabled { get; }

        event Func<string, Task> SelectedAccountChanged;
        event Func<int, Task> NetworkChanged;
        event Func<bool, Task> AvailabilityChanged;
        event Func<bool, Task> EnabledChanged;

        Task<bool> CheckProviderAvailabilityAsync();
        Task<Web3> GetWeb3Async();
        Task<string> EnableProviderAsync();
        Task<string> GetProviderSelectedAccountAsync();
        Task<int> GetProviderSelectedNetworkAsync();
        Task<string> SignMessageAsync(string message);
    }
}