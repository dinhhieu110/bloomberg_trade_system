using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.data;
using server.dtos.stock;
using server.mappers;

namespace server.controllers
{
  [Route("api/stocks")]
  [ApiController]
  public class StockController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    public StockController(ApplicationDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var stocks = await _context.Stocks.ToListAsync();
      var stockDTO = stocks.Select(stock => stock.ToStockDTO());
      return Ok(stocks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      var stock =await _context.Stocks.FindAsync(id);
      if (stock == null)
      {
        return NotFound();
      }
      return Ok(stock.ToStockDTO());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStockReqDTO newStock)
    {
      var stockModel = newStock.ToStockFromCreateDTO();
     await _context.AddAsync(stockModel);
     await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDTO());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockReqDTO updatedStock)
    {
      var stockModel = await _context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);
      if (stockModel == null)
      {
        return NotFound();
      }
      stockModel.Symbol = updatedStock.Symbol;
      stockModel.Purchase = updatedStock.Purchase;
      stockModel.Industry = updatedStock.Industry;
      stockModel.CompanyName = updatedStock.CompanyName;
      stockModel.MarketCap = updatedStock.MarketCap;
      stockModel.LastDiv = updatedStock.LastDiv;

     await _context.SaveChangesAsync();
      return Ok(stockModel.ToStockDTO());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var stockModel = await _context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);
      if (stockModel == null)
      {
        return NotFound();
      }
      _context.Stocks.Remove(stockModel);
     await _context.SaveChangesAsync();
      return NoContent();
    }
  }
}
