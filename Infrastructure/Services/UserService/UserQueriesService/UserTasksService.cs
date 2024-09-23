using Dapper;
using examAPI.ConnectionString;
using examAPI.Models.User.UserQueries;
using Npgsql;

namespace examAPI.Infrastructure.Services.UserService.UserQueriesService;

public class UserTasksService
{
    public async Task<IEnumerable<GetUserTasks>> GetUserTasks()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetUserTasks>(SqlCommand.Get);
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
    public const string Get = @"select u.id, u.userName, u.email,t.title,t.description,t.iscompleted,
                                                      t.duedate,t.userid,priority from tasks t 
                                                      join users u on u.id = t.userid";
}