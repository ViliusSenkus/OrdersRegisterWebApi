using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;
using DbUp;
using System;
using Application.Interfaces;

namespace Infrastructure
{
    public static class DependenciesInjection
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IOrdersRegisterRepository, OrdersRegisterRepository>();

            string dbConnectonString = config.GetConnectionString("postgres")
                    ?? throw new Exception("Connection string cannot be found.");

            services.AddScoped<IDbConnection>((serviceProvider) => new NpgsqlConnection(dbConnectonString));

            //DbUp
            EnsureDatabase.For.PostgresqlDatabase(dbConnectonString);
            var upgrader = DeployChanges.To
                    .PostgresqlDatabase(dbConnectonString)
                    .WithScriptsEmbeddedInAssembly(typeof(OrdersRegisterRepository).Assembly)
                    .LogToNowhere()
                    .Build();

            var result = upgrader.PerformUpgrade();
        }
    }
}
