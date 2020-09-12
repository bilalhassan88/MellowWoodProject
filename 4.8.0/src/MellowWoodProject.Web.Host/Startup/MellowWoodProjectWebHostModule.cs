using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MellowWoodProject.Configuration;

namespace MellowWoodProject.Web.Host.Startup
{
    [DependsOn(
       typeof(MellowWoodProjectWebCoreModule))]
    public class MellowWoodProjectWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MellowWoodProjectWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MellowWoodProjectWebHostModule).GetAssembly());
        }
    }
}
