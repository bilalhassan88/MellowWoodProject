using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MellowWoodProject.Authorization.Roles;
using MellowWoodProject.Authorization.Users;
using MellowWoodProject.MultiTenancy;

namespace MellowWoodProject.EntityFrameworkCore
{
    public class MellowWoodProjectDbContext : AbpZeroDbContext<Tenant, Role, User, MellowWoodProjectDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<CMS.CMS> CMS { get; set; }
        public MellowWoodProjectDbContext(DbContextOptions<MellowWoodProjectDbContext> options)
            : base(options)
        {
        }
    }
}
