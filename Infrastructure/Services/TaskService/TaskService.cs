using Dapper;
using examAPI.ConnectionString;
using examAPI.Models.Task;
using Npgsql;
using Task = examAPI.Models.Task.Task;

namespace examAPI.Infrastructure.Services.TaskService;

public class TaskService : ITaskService
{
    public async Task<IEnumerable<Task>> GetTasks()
    {
        try
        {
            using (NpgsqlConnection  connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<Task>(SqlCommandTask.Select);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Task?> GetTaskById(int taskId)
    {
        try
        {
            using (NpgsqlConnection  connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QuerySingleOrDefaultAsync<Task>(SqlCommandTask.SelectById, new { id = taskId });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateTask(Task task)
    {
        try
        {
            using (NpgsqlConnection  connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandTask.Insert, task) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateTask(Task taskId)
    {
        try
        {
            using (NpgsqlConnection  connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandTask.Update, taskId) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteTask(int taskId)
    {
        try
        {
            using (NpgsqlConnection  connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandTask.Delete, new { id = taskId }) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}