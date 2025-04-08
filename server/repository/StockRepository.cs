using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.data;
using server.dtos.stock;
using server.helpers;
using server.interfaces;
using server.models;

namespace server.repository
{
  public class StockRepository : IStockRepository
  {
    private readonly ApplicationDbContext _context;
    public StockRepository(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<List<Stock>> GetAllAsync(QueryObject query)
    {
      var stocks = _context.Stocks.Include(i => i.Comments).AsQueryable();
      if (!string.IsNullOrWhiteSpace(query.CompanyName))
      {
        //  return "APPLE INC, APPLE..." when searching "Apple" only
        stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
      }
      if (!string.IsNullOrWhiteSpace(query.Symbol))
      {
        stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
      }
      return await stocks.ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
      return await _context.Stocks.Include(i => i.Comments).FirstOrDefaultAsync(i=> i.Id == id);
    }

    public async Task<Stock> CreateAsync(Stock stockModel)
    {
      await _context.Stocks.AddAsync(stockModel);
      await _context.SaveChangesAsync();
      return stockModel;
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
      var stockModel = await _context.Stocks.FirstOrDefaultAsync(i => i.Id == id);

      if (stockModel == null)
      {
        return null;
      }
      _context.Stocks.Remove(stockModel);
      await _context.SaveChangesAsync();
      return stockModel;
    }



    public Task<bool> StockExists(int id)
    {
      return _context.Stocks.AnyAsync(i => i.Id == id);
    }

    public async Task<Stock?> UpdateAsync(int id, Stock updatedStock)
   {
      var stockModel = await _context.Stocks.FirstOrDefaultAsync(i => i.Id == id);

      if (stockModel == null)
      {
        return null;
      }
      stockModel.Symbol = updatedStock.Symbol;
      stockModel.Purchase = updatedStock.Purchase;
      stockModel.Industry = updatedStock.Industry;
      stockModel.CompanyName = updatedStock.CompanyName;
      stockModel.MarketCap = updatedStock.MarketCap;
      stockModel.LastDiv = updatedStock.LastDiv;

      await _context.SaveChangesAsync();
      return stockModel;
    }
  }
}
