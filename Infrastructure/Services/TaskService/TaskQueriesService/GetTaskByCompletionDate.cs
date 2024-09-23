using Dapper;
using examAPI.ConnectionString;
using Npgsql;

namespace examAPI.Infrastructure.Services.TaskService.TaskQueriesService;

public class GetTaskByCompletionDate
{
    public async Task<IEnumerable<GetTaskByCompletionDate>> SelectTaskByCompletionDate()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetTaskByCompletionDate>(SqlCommand.Get);
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
    public const string Get = @"select * from tasks 
                              order by createdat";
}