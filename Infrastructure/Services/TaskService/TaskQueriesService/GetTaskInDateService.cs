using Dapper;
using examAPI.ConnectionString;
using examAPI.Infrastructure.Services.TaskService.TaskQueries;
using Npgsql;

namespace examAPI.Infrastructure.Services.TaskService.TaskQueriesService;

public class GetTaskInDateService
{
    public async Task<IEnumerable<GetTaskInDate>> GetTaskInDate(DateTime dueDate)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetTaskInDate>(SqlCommand.Get, new { duedate = @dueDate });
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
    public const string Get = "select * from tasks where duedate = @dueDate";
}