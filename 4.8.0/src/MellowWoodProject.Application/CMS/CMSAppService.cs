using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using AutoMapper;
using MellowWoodProject.CMS.Dto;
using MellowWoodProject.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Authorization;
using MellowWoodProject.Authorization;

namespace MellowWoodProject.CMS
{

    public class CMSAppService : ICMSAppService
    {
        private readonly IRepository<CMS> _CMSrepository;

        public CMSAppService(IRepository<CMS> repository)
        {
            _CMSrepository = repository;
           
        }

        public CMS GetCMSContent(int id)
        {
            return _CMSrepository.FirstOrDefault(x=>x.Id == id);
        }

        public List<CMS> GetAll()
        {
            return _CMSrepository.GetAllList();
        }

        public CMS InsertOrUpdateCMSContent(CMSInfoDto dto)
        {
            var cms = new CMS()
            {
                pageContent = dto.pageContent,  
                pageName = dto.pageName,
                Id = dto.id
            };

            _CMSrepository.InsertOrUpdate(cms);

            return cms;
        }



    }
}
