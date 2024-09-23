using Dapper;
using examAPI.ConnectionString;
using examAPI.Models.TaskHistory.TaskHistoryQueries;
using Npgsql;

namespace examAPI.Infrastructure.Services.TaskHistory.TaskHistoryQueriesService;

public class GetTaskHistoryWithUuidService
{
    public async Task<IEnumerable<GetTaskHistoryWithUuid>> SelectTaskWithUUID(Guid taskId)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetTaskHistoryWithUuid>(SqlCommand.Get, new { taskid = @taskId });
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
    public const string Get = @"SELECT h.Id, h.TaskId, h.ChangeDescription, h.ChangedAt FROM TaskHistory h
                                WHERE h.TaskId = @taskId";
}