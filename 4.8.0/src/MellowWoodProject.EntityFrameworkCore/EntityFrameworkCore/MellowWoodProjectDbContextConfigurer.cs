using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MellowWoodProject.EntityFrameworkCore
{
    public static class MellowWoodProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MellowWoodProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MellowWoodProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
