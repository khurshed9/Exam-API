using Dapper;
using examAPI.ConnectionString;
using Npgsql;
using examAPI.Models.TaskAttachmentsSql;

namespace examAPI.Infrastructure.Services.TaskAttachment;

public class TaskAttachmentService : ITaskAttachmentService
{
    public async Task<IEnumerable<examAPI.Models.TaskAttachments.TaskAttachment>> GetTaskAttachments()
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QueryAsync<examAPI.Models.TaskAttachments.TaskAttachment>(SqlCommandTaskAttachment.Select);
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<examAPI.Models.TaskAttachments.TaskAttachment?> GetTaskAttachmentById(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.QuerySingleOrDefaultAsync<examAPI.Models.TaskAttachments.TaskAttachment>(SqlCommandTaskAttachment.SelectById, new { Id = id });
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> CreateTaskAttachment(examAPI.Models.TaskAttachments.TaskAttachment taskAttachment)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandTaskAttachment.Insert, taskAttachment) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> UpdateTaskAttachment(examAPI.Models.TaskAttachments.TaskAttachment taskAttachment)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandTaskAttachment.Update, taskAttachment) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<bool> DeleteTaskAttachment(int id)
    {
        try
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(Connection.ConnectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(SqlCommandTaskAttachment.Delete, new { Id = id }) > 0;
            }
        }
        catch (NpgsqlException e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}