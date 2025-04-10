using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.dtos.comment;
using server.extensions;
using server.interfaces;
using server.mappers;
using server.models;

namespace server.controllers
  {
  [Route("api/comments")]
  [ApiController]
  public class CommentController : ControllerBase
  {
    private readonly ICommentRepository _commentRepo;
    private readonly IStockRepository _stockRepo;
    private readonly UserManager<AppUser> _userManager;
    private readonly IFMPService _fMPService;

    public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo, UserManager<AppUser> userManager, IFMPService fMPService)
    {
      _commentRepo = commentRepo;
      _stockRepo = stockRepo;
      _userManager = userManager;
      _fMPService = fMPService;
    }

    [HttpGet]
    [Authorize]

    public async Task<IActionResult> GetAll()
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var comments = await _commentRepo.GetAllAsync();

      var commentDTOs = comments.Select(i => i.MapCommentAPIToDTO());

      return Ok(commentDTOs);
    }

    [HttpGet("{id:int}")]
    [Authorize]

    public async Task<IActionResult> GetById([FromRoute] int id)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
      var comment = await _commentRepo.GetByIdAsync(id);
      if (comment == null)
      {
        return NotFound();
      }
      return Ok(comment.MapCommentAPIToDTO());
    }

    [HttpPost("{symbol:alpha}")]
    [Authorize]

    public async Task<IActionResult> Create([FromRoute] string symbol, [FromBody] CreateCommentDTO newComment)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);
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

      var userEmail = User.GetUserEmail();
      var appUser = await _userManager.FindByEmailAsync(userEmail);

      var commentModel = newComment.MapCreateCommentDTOToAPI(stock
      .Id);
      commentModel.AppUserId = appUser.Id;
      await _commentRepo.CreateAsync(commentModel);
      return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.MapCommentAPIToDTO());

    }

    [HttpPut]
    [Authorize]

    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDTO updatedComment)
    {
      if(!ModelState.IsValid) return BadRequest(ModelState);
      var commentModel = await _commentRepo.UpdateAsync(id, updatedComment.ToCommentFromUpdateDTO());
      if (commentModel == null)
      {
        return NotFound("Comment not found");
      }
      return Ok(commentModel.MapCommentAPIToDTO());

    }

     [HttpDelete]
    [Authorize]

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
