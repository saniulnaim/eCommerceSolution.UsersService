using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace eCommerce.Infrastructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;

        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            //string? connectionString = _configuration.GetConnectionString("PostgresConnection");
            string connectionStringTemplate = _configuration.GetConnectionString("PostgresConnection")!;

            string connectionString = connectionStringTemplate
                .Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST")!)
                .Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")!)
                .Replace("$POSTGRES_USER", Environment.GetEnvironmentVariable("POSTGRES_USER")!)
                .Replace("$POSTGRES_DATABASE", Environment.GetEnvironmentVariable("POSTGRES_DATABASE")!)
                .Replace("$POSTGRES_PORT", Environment.GetEnvironmentVariable("POSTGRES_PORT")!);

            _connection = new NpgsqlConnection(connectionString);
        }

        public IDbConnection DbConnection => _connection;
    }
}
