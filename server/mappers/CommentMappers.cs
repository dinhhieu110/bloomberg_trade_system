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
    // Map to UI
    public static CommentDTO MapCommentAPIToDTO(this Comment commentModel)
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

    // Map to API
    public static Comment MapCreateCommentDTOToAPI(this CreateCommentDTO commentModel, int stockId)
    {
      return new Comment
      {
        Title = commentModel.Title,
        Content = commentModel.Content,
        StockId = stockId
      };
    }
     public static Comment ToCommentFromUpdateDTO(this UpdateCommentDTO commentModel)
    {
      return new Comment
      {
        Title = commentModel.Title,
        Content = commentModel.Content,
      };
    }

    }
}
