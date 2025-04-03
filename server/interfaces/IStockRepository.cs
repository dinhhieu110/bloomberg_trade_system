using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.dtos.stock;
using server.models;

namespace server.interfaces
{
  public interface IStockRepository
  {
    Task<List<Stock>> GetAllAsync();
    Task<Stock?> GetByIdAsync(int id);
    Task<Stock> CreateAsync(Stock stockModel);
    Task<Stock?> UpdateAsync(int id, UpdateStockReqDTO stockModel);
    Task<Stock?> DeleteAsync(int id);
    Task<bool> StockExists(int id);
    }
}
