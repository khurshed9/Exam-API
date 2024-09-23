using Dapper;
using examAPI.ConnectionString;
using examAPI.Infrastructure.Services.TaskService.TaskQueries;
using Npgsql;
using Task = examAPI.Models.Task.Task;

namespace examAPI.Infrastructure.Services.TaskService.TaskQueriesService;

public class GetTaskWithHighPriorityService
{
    public async Task<IEnumerable<GetTaskWithHighPriority>> GetHighPriority()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetTaskWithHighPriority>(SqlCommand.Get);
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
    public const string Get = @"select * from tasks t 
                              where priority = 'high'";
}