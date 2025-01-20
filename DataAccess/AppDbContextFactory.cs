using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class AppDbContextFactory
    {
        public AppDbContext CreateDbContext()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var user = Environment.GetEnvironmentVariable("ApexFit_DB_LOGIN_USER");
            var key = Environment.GetEnvironmentVariable("ApexFit_DB_LOGIN_KEY");

            string connectionString = configuration.GetConnectionString("DefaultDBConnection")
                .Replace("{ApexFit_DB_LOGIN_USER}", user)
                .Replace("{ApexFit_DB_LOGIN_KEY}", key);

            return new AppDbContext(connectionString);
        }
    }
}
