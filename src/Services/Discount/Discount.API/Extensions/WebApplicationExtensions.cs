using Npgsql;

namespace Discount.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplicationBuilder MigrateDatabase<TContext>(this WebApplicationBuilder builder, int? retry = 0)
        {
            var retryForAvailability = retry.Value;
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();
                using var connection = new NpgsqlConnection(configuration.GetValue<string>("Databasesettings:ConnectionString"));
                connection.Open();
                using var transactions = connection.BeginTransaction();

                try
                {
                    logger.LogInformation("Migrating postresql database.");
                    using var command = new NpgsqlCommand
                    {
                        Connection = connection,
                        Transaction = transactions
                    };

                    command.CommandText = @"DROP TABLE IF EXISTS Coupon;
                                            CREATE TABLE Coupon(Id SERIAL PRIMARY KEY, 
                                                                ProductName VARCHAR(24) NOT NULL,
                                                                Description TEXT,
                                                                Amount INT);
                                            INSERT INTO Coupon(ProductName, Description, Amount) VALUES('IPhone X', 'IPhone Discount', 150);
                                            INSERT INTO Coupon(ProductName, Description, Amount) VALUES('Samsung 10', 'Samsung Discount', 100);";
                    command.ExecuteNonQuery();
                    transactions.Commit();
                }
                catch (NpgsqlException ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the postresql database");
                    transactions.Rollback();

                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        Thread.Sleep(2000);
                        MigrateDatabase<TContext>(builder, retryForAvailability);
                    }
                }

                return builder;
            }
        }
    }
}