using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using MellowWoodProject.Configuration.Dto;

namespace MellowWoodProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : MellowWoodProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
