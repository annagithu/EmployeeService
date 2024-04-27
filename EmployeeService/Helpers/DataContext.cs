using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;

namespace EmployeeService.Helpers
{
    public class DataContext
    {
        private DbSettings _dbSettings;

        public DataContext(IOptions<DbSettings> dbSettings)
        {
            _dbSettings = dbSettings.Value;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = $"Host={_dbSettings.Server}; Database={_dbSettings.Database}; Username={_dbSettings.UserId}; Password={_dbSettings.Password};";
            return new NpgsqlConnection(connectionString);
        }

        public async Task Init()
        {
            await _initDatabase();
            
        }

        private async Task _initDatabase()
        {
            var connectionString = $"Host={_dbSettings.Server}; Database=postgres; Username={_dbSettings.UserId}; Password={_dbSettings.Password};";
            using var connection = new NpgsqlConnection(connectionString);
            var sqlDbCount = $"SELECT COUNT(*) FROM pg_database WHERE datname = '{_dbSettings.Database}';";
            var dbCount = await connection.ExecuteScalarAsync<int>(sqlDbCount);
            if (dbCount == 0)
            {
                var sql = $"CREATE DATABASE \"{_dbSettings.Database}\"";
                await connection.ExecuteAsync(sql);
                await _initTables();
            }
        }

        private async Task _initTables()
        {
            using var connection = CreateConnection();
            await _initTableEmployees();
            await _initTablePassports();
            await _initTableDepartments();

            async Task _initTableEmployees()
            {
                var sql = """
               CREATE TABLE employees (
                id int PRIMARY KEY,
                name varchar(50) NOT NULL,
            	surname varchar(50) NOT NULL,
            	phone varchar(11) NOT NULL,
            	companyId int NOT NULL,
            	passport varchar(10),
            	FOREIGN KEY (passport) REFERENCES passports(number),
            	department varchar(50),
            	FOREIGN KEY (department) REFERENCES departments(name)
            ); 
            """;
                await connection.ExecuteAsync(sql);
            }

            async Task _initTablePassports()
            {
                var sql = """
                CREATE TABLE IF NOT EXISTS passports (
                passporttype varchar(10) NOT NULL,
                passportnumber varchar(10) NOT NULL,
                employeeid integer NOT NULL
            );
            """;
                await connection.ExecuteAsync(sql);
            }

            async Task _initTableDepartments()
            {
                var sql = """
                CREATE TABLE IF NOT EXISTS departments (
                departmentname varchar(50) NOT NULL,
                departmentphone varchar(11) NOT NULL,
                employeeid integer NOT NULL
            );
            """;
                await connection.ExecuteAsync(sql);
            }

        }
    }
}
