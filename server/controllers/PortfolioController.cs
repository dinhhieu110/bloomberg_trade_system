using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.extensions;
using server.interfaces;
using server.models;

namespace server.controllers
{
  [Route("api/portfolio")]
  public class PortfolioController : ControllerBase
  {
    private readonly UserManager<AppUser> _userManager;
    private readonly IStockRepository _stockRepo;
    private readonly IPortfolioRepository _portfolioRepo;
    private readonly IFMPService _fMPService;


    public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepository, IPortfolioRepository portfolioRepo, IFMPService fMPService)
    {
      _stockRepo = stockRepository;
      _userManager = userManager;
      _portfolioRepo = portfolioRepo;
      _fMPService = fMPService;

    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUserPortfolio()
    {
      var userEmail = User.GetUserEmail();
      var appUser = await _userManager.FindByEmailAsync(userEmail);
      var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);
      return Ok(userPortfolio);
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddUserPortfolio(string symbol)
    {
      var userEmail = User.GetUserEmail();
      var appUser = await _userManager.FindByEmailAsync(userEmail);
      var stock = await _stockRepo.GetBySymbolAsync(symbol);

 // This means this stock is not in our local DB --> check stock on financial modeling prep
      if (stock == null)
      {
        stock = await _fMPService.FindStockBySymbolAsync(symbol);
        if (stock == null)
        {
          return BadRequest("Stock does not exist!");
        }
        else
        {
          await _stockRepo.CreateAsync(stock);
        }
      }


      if (stock == null) return BadRequest("Stock not found!");

      var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);

      if (userPortfolio.Any(i => i.Symbol.ToLower() == symbol.ToLower())) return BadRequest("Duplicate stock in portfolio!");

      var portfolioModel = new Portfolio
      {
        StockId = stock.Id,
        AppUserId = appUser.Id
      };

      await _portfolioRepo.CreateAsync(portfolioModel);

      if (portfolioModel == null)
      {
        return StatusCode(500, "Could not create");
      }
      else
      {
        return Created();
      }
    }
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeletePortfolio(string symbol)
    {
      var userEmail = User.GetUserEmail();
      var appUser = await _userManager.FindByEmailAsync(userEmail);

      var userPortfolio = await _portfolioRepo.GetUserPortfolio(appUser);

      var filterStocks = userPortfolio.Where(favoriteStock => favoriteStock.Symbol.ToLower() == symbol.ToLower());

      if (filterStocks.Count() == 1)
      {
        await _portfolioRepo.DeletePortfolio(appUser, symbol);
      }
      else
      {
        return BadRequest("Stock is not in your porfolio!");
      }

      return Ok();

    }
  }
}
