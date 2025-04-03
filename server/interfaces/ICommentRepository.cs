using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.dtos.comment;
using server.models;

namespace server.interfaces
{
  public interface ICommentRepository
  {
    Task<List<Comment>> GetAllAsync();
    Task<Comment?> GetByIdAsync(int id);

    Task<Comment> CreateAsync(Comment newComment);
    Task<Comment> UpdateAsync(int id, UpdatedReqDTO newComment);
    Task<Comment?> DeleteAsync(int id);

  }
}
