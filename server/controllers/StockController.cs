using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    public IActionResult GetAll()
    {
      var stocks = _context.Stocks.ToList()
      .Select(stock => stock.ToStockDTO());
      return Ok(stocks);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
      var stock = _context.Stocks.Find(id);
      if (stock == null)
      {
        return NotFound();
      }
      return Ok(stock.ToStockDTO());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateStockReqDTO newStock)
    {
      var stockModel = newStock.ToStockFromCreateDTO();
      _context.Add(stockModel);
      _context.SaveChanges();
      return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDTO());
    }
  }
}
