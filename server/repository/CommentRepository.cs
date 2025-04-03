using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.data;
using server.interfaces;
using server.models;

namespace server.repository
{
    public class CommentRepository: ICommentRepository
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
  }
}
