using Abp.Application.Services;
using MellowWoodProject.CMS.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MellowWoodProject.CMS
{
    public interface ICMSAppService : IApplicationService
    {
        CMS GetCMSContent(int pageId);
        CMS InsertOrUpdateCMSContent(CMSInfoDto dto);
        List<CMS> GetAll();

    }
}
