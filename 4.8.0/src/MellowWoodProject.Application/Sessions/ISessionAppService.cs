using System.Threading.Tasks;
using Abp.Application.Services;
using MellowWoodProject.Sessions.Dto;

namespace MellowWoodProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
