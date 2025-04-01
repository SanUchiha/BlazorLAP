namespace BlazorLAP.Configurations;

public class ConnectionConfiguration(string connectionString)
{
    private readonly string _connectionString = connectionString;

    public string ConnectionString { get => _connectionString; }
}
