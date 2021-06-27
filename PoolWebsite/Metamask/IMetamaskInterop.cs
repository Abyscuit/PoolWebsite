using Nethereum.JsonRpc.Client.RpcMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PoolWebsite.Metamask
{
    public interface IMetamaskInterop
    {
        ValueTask<string> EnableEthereumAsync();
        ValueTask<bool> CheckMetamaskAvailability();
        ValueTask<string> GetSelectedAddress();
        ValueTask<RpcResponseMessage> SendAsync(RpcRequestMessage rpcRequestMessage);
        ValueTask<RpcResponseMessage> SendTransactionAsync(MetamaskRpcRequestMessage rpcRequestMessage);
        ValueTask<string> SignAsync(string utf8Hex);
    }
}