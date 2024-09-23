using Dapper;
using examAPI.ConnectionString;
using examAPI.Infrastructure.Models.TaskAttachment.TaskAttachmentQueries;
using Npgsql;

namespace examAPI.Infrastructure.Services.TaskAttachment.TaskAttachmentQueriesService;

public class GetAllTaskAttachmentsTaskUserService
{
    public async Task<IEnumerable<GetAllTaskAttachmentsTaskUser>> GetAllTaskAttachmentsTaskUsers(Guid taskId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetAllTaskAttachmentsTaskUser>(SqlCommand.Get,new {taskid = @taskId});
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
    public const string Get =
        @"select ta.FilePath,ta.CreatedAt,u.UserName,u.Email from TaskAttachments as ta
        join tasks as t on ta.taskId = t.id
        join users as u on t.userId=u.id
        where ta.taskid=@taskId";
}