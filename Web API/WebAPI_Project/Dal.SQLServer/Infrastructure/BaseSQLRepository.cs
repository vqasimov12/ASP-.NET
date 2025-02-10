using Microsoft.Data.SqlClient;

namespace Dal.SQLServer.Infrastructure;

public abstract class BaseSQLRepository
{
    private readonly string _connnectionString;

    internal BaseSQLRepository(string connnectionString)
    {
        _connnectionString = connnectionString;
    }

    protected SqlConnection OpenConnection()
    {
        var conn = new SqlConnection(_connnectionString);
        conn.Open();
        return conn;
    }



}