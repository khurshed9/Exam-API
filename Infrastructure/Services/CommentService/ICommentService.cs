using examAPI.Models.Comment;

namespace examAPI.Infrastructure.Services.CommentService;

public interface ICommentService
{
    Task<IEnumerable<Comment>> GetComments();
    
    Task<Comment> GetCommentById(int commmentId);
    
    Task<bool> CreateComment(Comment comment);
    
    Task<bool> UpdateComment(Comment commentId);
    
    Task<bool> DeleteComment(int commentId);
}