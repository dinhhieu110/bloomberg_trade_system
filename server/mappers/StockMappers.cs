using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.dtos.stock;
using server.models;

namespace server.mappers
{
  public static class StockMappers
  {
    public static StockDTO ToStockDTO(this Stock stockModel)
    {
      return new StockDTO
      {
        Id = stockModel.Id,
        Symbol = stockModel.Symbol,
        CompanyName = stockModel.CompanyName,
        Purchase = stockModel.Purchase,
        LastDiv = stockModel.LastDiv,
        Industry = stockModel.Industry,
        MarketCap = stockModel.MarketCap
      };
    }

     public static Stock ToStockFromCreateDTO(this CreateStockReqDTO stockModel)
    {
      return new Stock
      {
        Symbol = stockModel.Symbol,
        CompanyName = stockModel.CompanyName,
        Purchase = stockModel.Purchase,
        LastDiv = stockModel.LastDiv,
        Industry = stockModel.Industry,
        MarketCap = stockModel.MarketCap
      };
    }

    }
}
