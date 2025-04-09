using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.data;
using server.interfaces;
using server.models;

namespace server.repository
{
  public class PortfolioRepository:IPortfolioRepository
  {
    private readonly ApplicationDbContext _context;

    public PortfolioRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public Task<Portfolio> CreateAsync(Portfolio portfolio)
    {
      throw new NotImplementedException();
    }

    public Task<Portfolio> DeletePortfolio(AppUser appUser, string symbol)
    {
      throw new NotImplementedException();
    }

    public async Task<List<Stock>> GetUserPortfolio(AppUser user)
    {
      var all = await _context.Portfolios.ToListAsync();
foreach (var p in all)
{
    Console.WriteLine($"Portfolio AppUserId: {p.AppUserId}");
}
      return await _context.Portfolios.Where(u => u.AppUserId == user.Id)
      .Select(stock => new Stock
      {
        Id = stock.StockId,
        Symbol = stock.Stock.Symbol,
        CompanyName = stock.Stock.CompanyName,
        Industry = stock.Stock.Industry,
        LastDiv = stock.Stock.LastDiv,
        MarketCap = stock.Stock.MarketCap,
        Purchase = stock.Stock.Purchase
      }).ToListAsync();
    }
  }
}
