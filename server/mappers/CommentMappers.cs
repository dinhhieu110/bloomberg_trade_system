using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.dtos.comment;
using server.models;

namespace server.mappers
{
    public static class CommentMappers
    {
    public static CommentDTO ToCommentDTO(this Comment commentModel)
    {
      return new CommentDTO
      {
        Id = commentModel.Id,
        Title = commentModel.Title,
        Content = commentModel.Content,
        CreatedOn = commentModel.CreatedOn,
        StockId = commentModel.StockId
      };
        }
    }
}
