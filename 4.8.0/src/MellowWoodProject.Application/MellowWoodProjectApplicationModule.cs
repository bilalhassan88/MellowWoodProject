using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MellowWoodProject.Authorization;

namespace MellowWoodProject
{
    [DependsOn(
        typeof(MellowWoodProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MellowWoodProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MellowWoodProjectAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MellowWoodProjectApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
