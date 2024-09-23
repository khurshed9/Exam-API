using Dapper;
using examAPI.ConnectionString;
using examAPI.Models.Category.CategoryQueries;
using Npgsql;

namespace examAPI.Infrastructure.Services.CategoryService.CategoryQueriesService;

public class SumOfCategoryTaskService
{
    public async Task<IEnumerable<GetCategoryTask>> GetCategoryTask()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<GetCategoryTask>(SqlCommand.Get);
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
    public const string Get = @"select c.id, c.name, c.createdat,Count(t.id) as sum from tasks t
                              join categories c on c.id = t.categoryid
                              group by c.id, c.name, c.createdat";
}