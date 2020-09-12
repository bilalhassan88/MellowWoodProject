using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MellowWoodProject.MultiTenancy;

namespace MellowWoodProject.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
