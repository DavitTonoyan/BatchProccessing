using BatchProccessing.ChunkProccess;
using BatchProccessing.Models;
using Dapper;
using JobTest.Models;
using System.Data.SqlClient;

namespace JobTest;

public class Reader : IReader
{
    string connectionString = "Server=DESKTOP-T7VJTNV\\SQLEXPRESS;Database=XMessenger;Trusted_Connection=True;TrustServerCertificate=True";



    public async Task<ReadModel[]> Read(int start, int end)
    {
        using SqlConnection sqlConnection = new SqlConnection(connectionString);

        string query = @$"
                         SELECT [Id] 
                             ,[FromMemberId] 
                             ,[ToMemberId] 
                             ,[Text] 
                         FROM [XMessenger].[dbo].[Message] 
                         where Id > {start} and Id<= {end} ";

        var messages = await sqlConnection.QueryAsync<MessageReadModel>(query);

        return messages.ToArray();
    }
}
