using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.data;
using server.dtos.comment;
using server.interfaces;
using server.models;

namespace server.repository
{
  public class CommentRepository : ICommentRepository
  {
    private readonly ApplicationDbContext _context;
    public CommentRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<List<Comment>> GetAllAsync()
    {
      return await _context.Comments.ToListAsync();

    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
      return await _context.Comments.FindAsync(id);
    }

    public async Task<Comment> CreateAsync(Comment newComment)
    {
      await _context.Comments.AddAsync(newComment);
      await _context.SaveChangesAsync();
      return newComment;
    }

    public async Task<Comment> UpdateAsync(int id, UpdatedReqDTO newComment)
    {
      var commentModel = _context.Comments.FirstOrDefault(i => i.Id ==id );
      if (commentModel == null)
      {
        return null;
      }
      commentModel.Title = newComment.Title;
      commentModel.CreatedOn = newComment.CreatedOn;
      commentModel.Content = newComment.Content;
      commentModel.StockId = newComment.StockId;

      await _context.SaveChangesAsync();
      return commentModel;
    }

    public async Task<Comment?> DeleteAsync(int id)
    {
      var commentModel = await _context.Comments.FirstOrDefaultAsync(i => i.Id == id);

      if (commentModel == null)
      {
        return null;
      }

      _context.Comments.Remove(commentModel);
      await _context.SaveChangesAsync();
      return commentModel;
    }
  }
}
