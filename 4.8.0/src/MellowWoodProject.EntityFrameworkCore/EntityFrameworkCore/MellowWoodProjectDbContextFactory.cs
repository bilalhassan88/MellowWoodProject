using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MellowWoodProject.Configuration;
using MellowWoodProject.Web;

namespace MellowWoodProject.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MellowWoodProjectDbContextFactory : IDesignTimeDbContextFactory<MellowWoodProjectDbContext>
    {
        public MellowWoodProjectDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MellowWoodProjectDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MellowWoodProjectDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MellowWoodProjectConsts.ConnectionStringName));

            return new MellowWoodProjectDbContext(builder.Options);
        }
    }
}
