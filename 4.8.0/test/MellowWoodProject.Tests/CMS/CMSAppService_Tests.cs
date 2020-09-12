using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Abp.Application.Services.Dto;
using MellowWoodProject.Users;
using MellowWoodProject.Users.Dto;
using MellowWoodProject.Tests;
using MellowWoodProject.CMS.Dto;

namespace MellowWoodProject.CMS
{
    public class CMSAppService_Tests : MellowWoodProjectTestBase
    {
        private readonly ICMSAppService _cmsAppService;

        public CMSAppService_Tests()
        {
            _cmsAppService = Resolve<ICMSAppService>();
        }

        [Fact]
        public void InsertorUpdate_Test()
        {
            
            CMSInfoDto c = new CMSInfoDto()
            {
                pageName = "MK",
                pageContent = "The page of Hanzo Hasashi"
            };

            var result =  _cmsAppService.InsertOrUpdateCMSContent(c);

            Assert.Equal(c.pageContent,result.pageContent);

        }


        [Fact]
        public void GetCMSContent_Test()
        {

            CMSInfoDto c = new CMSInfoDto()
            {
                pageName = "Metal Gear Solid",
                pageContent = "The story of Les Enfant Terribles "
            };

            _cmsAppService.InsertOrUpdateCMSContent(c);

            var result = _cmsAppService.InsertOrUpdateCMSContent(c);

            var output = _cmsAppService.GetCMSContent(result.Id);

            Assert.Equal(c.pageContent, output.pageContent);

        }


        [Fact]
        public void GetAll_Test()
        {

            CMSInfoDto c = new CMSInfoDto()
            {
                pageName = "LOUT2",
                pageContent = "Ellie and Abbey's long adventure"
            };

            _cmsAppService.InsertOrUpdateCMSContent(c);

            CMSInfoDto d = new CMSInfoDto()
            {
                pageName = "GOW",
                pageContent = "The long post of his dad and his father."
            };

            _cmsAppService.InsertOrUpdateCMSContent(d);

            var result = _cmsAppService.GetAll().Count;

            Assert.Equal(2, result);

        }

    }
}
