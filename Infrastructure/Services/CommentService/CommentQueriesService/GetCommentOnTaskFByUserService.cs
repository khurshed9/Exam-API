using Dapper;
using examAPI.ConnectionString;
using examAPI.Models.Comment.CommentQueries;
using Npgsql;

namespace examAPI.Infrastructure.Services.CommentService.CommentQueriesService;

public class GetCommentOnTaskFByUserService
{
    public async Task<IEnumerable<GetCommentOnTaskFilteredByUser>> SelectCommentOnTaskFilteredByUser(Guid taskId,Guid userId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetCommentOnTaskFilteredByUser>(SqlCommand.Get, new {taskid = @taskId, userid = @userId});
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}

file class SqlCommand
{
    public const string Get = "SELECT c.Id, c.TaskId, c.UserId, c.Content, c.CreatedAt FROM Comments c " +
                              "WHERE c.TaskId = @taskId AND" +
                              " c.UserId = userId;";
}