using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MellowWoodProject.MultiTenancy.Dto;

namespace MellowWoodProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

