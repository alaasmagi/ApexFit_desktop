using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess
{
    public class AppDbContextFactory
    {
        public AppDbContext CreateDbContext()
        {
            var user = Environment.GetEnvironmentVariable("ApexFit_DB_LOGIN_USER");
            var key = Environment.GetEnvironmentVariable("ApexFit_DB_LOGIN_KEY");

            string rawConnectionString = ConfigurationManager.ConnectionStrings["DefaultDBConnection"].ConnectionString;

            string connectionString = rawConnectionString
                .Replace("${ApexFit_DB_LOGIN_USER}", user)
                .Replace("${ApexFit_DB_LOGIN_KEY}", key);

            return new AppDbContext(connectionString);
        }
    }
}
