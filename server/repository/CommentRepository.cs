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

    public async Task<Comment> UpdateAsync(int id, Comment updatedComment)
       {
      var commentModel = _context.Comments.FirstOrDefault(i => i.Id ==id );
      if (commentModel == null)
      {
        return null;
      }
      commentModel.Title = updatedComment.Title;
      commentModel.Content = updatedComment.Content;


      await _context.SaveChangesAsync();
      return commentModel;
    }
  }
}
