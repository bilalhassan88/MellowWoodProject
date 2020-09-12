using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MellowWoodProject.Controllers
{
    public abstract class MellowWoodProjectControllerBase: AbpController
    {
        protected MellowWoodProjectControllerBase()
        {
            LocalizationSourceName = MellowWoodProjectConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
