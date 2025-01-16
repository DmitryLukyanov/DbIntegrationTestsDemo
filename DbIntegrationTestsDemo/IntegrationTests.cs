using Microsoft.Data.SqlClient;
using System.Data;

namespace DbIntegrationTestsDemo
{
    public class IntegrationTests
    {
        private readonly string _connectionString;
        public IntegrationTests()
        {
            _connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new InvalidOperationException("CONNECTION_STRING environment variable is not specified");
        }

        [Fact]
        public async Task Ensure_database_have_4_default_databases()
        {
            var allDefaultDatabases = await ReadDatabase("SELECT * FROM sys.databases");

            Assert.Equal(expected: 4, allDefaultDatabases.Rows.Count);
        }

        [Fact]
        public async Task TenMostExpensiveProducts_procedure_should_return_expected_result()
        {
            const string storedProcedure = "Ten Most Expensive Products";
            var storedProcedureResult = await CallStoredProcedure(storedProcedure);
            var result = storedProcedureResult.AsEnumerable().Select(i => new { ProductName = i["TenMostExpensiveProducts"].ToString(), UnitPrice = (decimal)i["UnitPrice"] }).ToArray();

            Assert.Equal(expected: 263.5000M, result[0].UnitPrice);
            Assert.Equal(expected: 123.7900M, result[1].UnitPrice);
            Assert.Equal(expected: 97.0000M, result[2].UnitPrice);
            Assert.Equal(expected: 81.0000M, result[3].UnitPrice);
            Assert.Equal(expected: 62.5000M, result[4].UnitPrice);
            Assert.Equal(expected: 55.0000M, result[5].UnitPrice);
            Assert.Equal(expected: 53.0000M, result[6].UnitPrice);
            Assert.Equal(expected: 49.3000M, result[7].UnitPrice);
            Assert.Equal(expected: 46.0000M, result[8].UnitPrice);
            Assert.Equal(expected: 45.6000M, result[9].UnitPrice);
        }


        [Fact]
        public async Task Ensure_all_tables_are_inserted()
        {
            var expectedTablesAfterAppliedScripts = new[] { "Orders", "Products", "Customers", "Employees" };

            var allDefaultTables = await ReadDatabase("SELECT * FROM INFORMATION_SCHEMA.TABLES");
            var tableNames = allDefaultTables.AsEnumerable().Select(i => i["TABLE_NAME"]);

            const int ExpectedNumberOfTablesAfterAppliedSQLScripts = 35; // otherwise => 6
            Assert.Equal(expected: ExpectedNumberOfTablesAfterAppliedSQLScripts, allDefaultTables.Rows.Count);

            foreach (var expectedTable in expectedTablesAfterAppliedScripts)
            {
                Assert.Contains(expected: expectedTable, tableNames);
            }
        }

        private async Task<DataTable> ReadDatabase(string query)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using SqlCommand command = new(query, connection);

            DataTable resultsTable = new();
            using var reader = await command.ExecuteReaderAsync();

            resultsTable.Load(reader);
            return resultsTable;
        }


        public async Task<DataTable> CallStoredProcedure(string storedProcedure)
        {
            using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            using SqlCommand command = new(storedProcedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            DataTable resultsTable = new();

            using var reader = await command.ExecuteReaderAsync();

            resultsTable.Load(reader);
            return resultsTable;
        }
    }
}