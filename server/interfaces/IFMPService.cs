using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.models;

namespace server.interfaces
{
    public interface IFMPService
    {
    Task<Stock> FindStockBySymbolAsync(string symbol);
    }
}
