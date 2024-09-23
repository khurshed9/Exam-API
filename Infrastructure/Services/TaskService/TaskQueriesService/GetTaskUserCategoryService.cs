using Dapper;
using examAPI.ConnectionString;
using Npgsql;

namespace examAPI.Infrastructure.Services.TaskService.TaskQueriesService;

public class GetTaskUserCategoryService
{
    public async Task<IEnumerable<TaskQueries.GetTaskUserCategory>> GetTaskUserCategory()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<TaskQueries.GetTaskUserCategory>(SqlCommand.Get);
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
    public const string Get = @"select t.title,u.id as userid,u.username, u.email, u.passwordhash,u.createdat,
                                c.id as categoryid,c.name as categoryname,c.createdat from tasks t 
                                join users u on u.id = t.userid
                                join categories c on c.id = t.categoryid";
}