using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
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

    public async Task<Portfolio> CreateAsync(Portfolio portfolio)
    {
      await _context.Portfolios.AddAsync(portfolio);
      await _context.SaveChangesAsync();
      return portfolio;
    }

    public async Task<Portfolio> DeletePortfolio(AppUser appUser, string symbol)
    {
      var portfolioModel = await _context.Portfolios.FirstOrDefaultAsync(x => x.AppUserId == appUser.Id && x.Stock.Symbol.ToLower() == symbol.ToLower());
      if (portfolioModel == null) return null;
      _context.Portfolios.Remove(portfolioModel);
      await _context.SaveChangesAsync();
      return portfolioModel;
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
