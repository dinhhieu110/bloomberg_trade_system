using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

    public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepository, IPortfolioRepository portfolioRepo)
    {
      _stockRepo = stockRepository;
      _userManager = userManager;
      _portfolioRepo = portfolioRepo;
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

  }
}
