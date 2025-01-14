using Microsoft.Data.SqlClient;
using System.Data;

namespace DbIntegrationTestsDemo
{
    public class IntegrationTests
    {
        private readonly string _connectionString;
        public IntegrationTests()
        {
            _connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new InvalidOperationException("CONNECTION_STRING_2 environment variable is not specified");
        }

        [Fact]
        public async Task Ensure_database_have_4_default_databases()
        {
            var allDefaultTables = await ReadDatabase("SELECT * FROM sys.databases");
            Assert.Equal(expected: 4, allDefaultTables.Rows.Count);
        }

        [Fact]
        public async Task Ensure_all_tables_are_inserted()
        {
            var allDefaultTables = await ReadDatabase("SELECT * FROM INFORMATION_SCHEMA.TABLES");

            const int ExpectedNumberOfTablesAfterAppledQLScripts = 35; // otherwise => 6
            Assert.Equal(expected: ExpectedNumberOfTablesAfterAppledQLScripts, allDefaultTables.Rows.Count);
        }

        private async Task<DataTable> ReadDatabase(string query)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using SqlCommand command = new(query, connection);

            DataTable resultsTable = new();
            var reader = await command.ExecuteReaderAsync();

            resultsTable.Load(reader);
            return resultsTable;
        }
    }
}