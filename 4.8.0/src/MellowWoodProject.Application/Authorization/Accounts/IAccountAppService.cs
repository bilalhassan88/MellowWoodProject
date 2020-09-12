using System.Threading.Tasks;
using Abp.Application.Services;
using MellowWoodProject.Authorization.Accounts.Dto;

namespace MellowWoodProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
