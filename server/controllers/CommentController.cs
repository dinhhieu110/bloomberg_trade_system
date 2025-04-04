using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.dtos.comment;
using server.interfaces;
using server.mappers;

namespace server.controllers
  {
  [Route("api/comments")]
  [ApiController]
  public class CommentController : ControllerBase
  {
    private readonly ICommentRepository _commentRepo;
    private readonly IStockRepository _stockRepo;

    public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
    {
      _commentRepo = commentRepo;
      _stockRepo = stockRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      if(!ModelState.IsValid) return BadRequest(ModelState);
      var comments = await _commentRepo.GetAllAsync();

      var commentDTOs = comments.Select(i => i.ToCommentDTO());

      return Ok(commentDTOs);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      if(!ModelState.IsValid) return BadRequest(ModelState);
      var comment = await _commentRepo.GetByIdAsync(id);
      if (comment == null)
      {
        return NotFound();
      }
      return Ok(comment.ToCommentDTO());
    }

    [HttpPost("{stockId:int}")]
    public async Task<IActionResult> Create([FromRoute] int stockId,[FromBody] CreateCommentReqDTO newComment)
    {
      if(!ModelState.IsValid) return BadRequest(ModelState);
      if (!await _stockRepo.StockExists(stockId))
      {
        return BadRequest("Stock dost not exist...");
      }
      ;
      var commentModel = newComment.ToCommentFromCreateDTO(stockId);
      await _commentRepo.CreateAsync(commentModel);
      return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDTO());

    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatedReqDTO updatedComment)
    {
      if(!ModelState.IsValid) return BadRequest(ModelState);
      var commentModel = await _commentRepo.UpdateAsync(id, updatedComment.ToCommentFromUpdateDTO(id));
      if (commentModel == null)
      {
        return NotFound();
      }
      return Ok(commentModel.ToCommentDTO());

    }

     [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      if(!ModelState.IsValid) return BadRequest(ModelState);
      var commentModel = await _commentRepo.DeleteAsync(id);
      if (commentModel == null)
      {
        return NotFound();
      }
      return NoContent();

    }
  }
}
