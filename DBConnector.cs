using Microsoft.Data.SqlClient;

namespace ConsoleAppTOConnectTODB;

public class DBConnector
{
    readonly string ConnectionString;

    public DBConnector(string connectionString)
    {
        ConnectionString = connectionString;
    }

    
}
