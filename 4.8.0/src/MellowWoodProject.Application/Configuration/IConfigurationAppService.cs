using System.Threading.Tasks;
using MellowWoodProject.Configuration.Dto;

namespace MellowWoodProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
