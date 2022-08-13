using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Configurations.Filters.Logs
{

    public class MsSqlLogger
    {
        public ILogger _loggerManager;
        public MsSqlLogger(IConfiguration configuration)
        {
            var sinkOption = new MSSqlServerSinkOptions()
            {
                TableName = "Logs",
                AutoCreateSqlTable = true//veritabanında log tablosu yoksa otomatik oluşturur
            };

            var columnOptions = new ColumnOptions();
            columnOptions.Store.Remove(StandardColumn.Message);
            columnOptions.Store.Remove(StandardColumn.Properties);

            var seriLogConfiguration = new LoggerConfiguration().WriteTo
                .MSSqlServer(
                    connectionString: configuration.GetConnectionString("ConnString"),
                    sinkOptions: sinkOption,
                    columnOptions: columnOptions); //(builder desenine örnek bir kullanım)


            _loggerManager = seriLogConfiguration.CreateLogger();
        }
    }
}
