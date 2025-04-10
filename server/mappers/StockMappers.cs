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
    public static StockDTO MapStockAPIToDTO(this Stock stockModel)
    {
      return new StockDTO
      {
        Id = stockModel.Id,
        Symbol = stockModel.Symbol,
        CompanyName = stockModel.CompanyName,
        Purchase = stockModel.Purchase,
        LastDiv = stockModel.LastDiv,
        Industry = stockModel.Industry,
        MarketCap = stockModel.MarketCap,
        Comments = stockModel.Comments.Select(i => i.MapCommentAPIToDTO()).ToList()
      };
    }

    public static Stock MapCreateStockDTOToAPI(this CreateStockDTO stockModel)
    {
      return new Stock
      {
        Symbol = stockModel.Symbol,
        CompanyName = stockModel.CompanyName,
        Purchase = stockModel.Purchase,
        LastDiv = stockModel.LastDiv,
        Industry = stockModel.Industry,
        MarketCap = stockModel.MarketCap,

      };
    }

    public static Stock MapFMPStockToAPI(this FMPStock fmpStockModel)
    {
      return new Stock
      {
        Symbol = fmpStockModel.symbol,
        CompanyName = fmpStockModel.companyName,
        Purchase = (decimal)fmpStockModel.price,
        LastDiv = (decimal)fmpStockModel.lastDiv,
        Industry = fmpStockModel.industry,
        MarketCap = fmpStockModel.mktCap,

      };
    }

     public static Stock ToStockFromUpdateDTO(this UpdateStockDTO stockModel)
    {
      return new Stock
      {
        Symbol = stockModel.Symbol,
        CompanyName = stockModel.CompanyName,
        Purchase = stockModel.Purchase,
        LastDiv = stockModel.LastDiv,
        Industry = stockModel.Industry,
        MarketCap = stockModel.MarketCap,

      };
    }

    }
}
