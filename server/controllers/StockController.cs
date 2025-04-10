using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.data;
using server.dtos.stock;
using server.helpers;
using server.interfaces;
using server.mappers;

namespace server.controllers
{
  [Route("api/stocks")]
  [ApiController]
  public class StockController : ControllerBase
  {
    private readonly ApplicationDbContext _context;
    private readonly IStockRepository _stockRepo;

    public StockController(ApplicationDbContext context, IStockRepository stockRepo)
    {
      _stockRepo = stockRepo;
      _context = context;
    }

    [HttpGet]
    [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var stocks = await _stockRepo.GetAllAsync(query);
      var stockDTO = stocks.Select(stock => stock.MapStockAPIToDTO()).ToList();
      return Ok(stockDTO);
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var stock = await _stockRepo.GetByIdAsync(id);
      if (stock == null)
      {
        return NotFound();
      }
      return Ok(stock.MapStockAPIToDTO());
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateStockDTO newStock)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var stockModel = newStock.MapCreateStockDTOToAPI();
      await _stockRepo.CreateAsync(stockModel);
      return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.MapStockAPIToDTO());
    }

    [HttpPut]
    [Authorize]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockDTO updatedStock)
    {
      if(!ModelState.IsValid) return BadRequest(ModelState);
      var stockModel = await _stockRepo.UpdateAsync(id, updatedStock.ToStockFromUpdateDTO());
      if (stockModel == null)
      {
        return NotFound();
      }
      return Ok(stockModel.MapStockAPIToDTO());
    }

    [HttpDelete]
    [Authorize]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      if(!ModelState.IsValid) return BadRequest(ModelState);
      var stockModel = await _stockRepo.DeleteAsync(id);
      if (stockModel == null)
      {
        return NotFound();
      }
      return NoContent();
    }
  }
}
