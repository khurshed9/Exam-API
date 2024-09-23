using Dapper;
using examAPI.ConnectionString;
using examAPI.Infrastructure.Services.TaskService.TaskQueries;

namespace examAPI.Infrastructure.Services.TaskService.TaskQueriesService;
using Npgsql;

public class GetCompletedPriorityTaskService
{
    public async Task<IEnumerable<GetCompletedPriorityTask>> GetTaskByCompletionDate(bool isCompleted, string priority)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetCompletedPriorityTask>(SqlCommand.Get,
                    new { IsCompleted = @isCompleted, Priority = @priority });
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
    public const string Get = "SELECT * FROM tasks " +
                              "WHERE iscompleted = @isCompleted AND priority = @priority;";
}