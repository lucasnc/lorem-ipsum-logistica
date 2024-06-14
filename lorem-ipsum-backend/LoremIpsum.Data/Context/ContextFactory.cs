using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LoremIpsum.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<LoremIpsumContext>
    {
        public LoremIpsumContext CreateDbContext(string[] args)
        {
            var relativePath = @"../lorem-ipsum-api";
            var absolutePath = System.IO.Path.GetFullPath(relativePath);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(absolutePath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("db_connection");

            //var connectionString = "Server=localhost\\SQLEXPRESS;Database=LoremIpsum;User Id=sa;Password=admin;TrustServerCertificate=True;";
            var optionBuilder = new DbContextOptionsBuilder<LoremIpsumContext>();
            optionBuilder.UseSqlServer(connectionString);
            return new LoremIpsumContext(optionBuilder.Options);
        }
    }
}
