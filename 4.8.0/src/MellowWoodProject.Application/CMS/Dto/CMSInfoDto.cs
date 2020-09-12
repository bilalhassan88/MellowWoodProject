using Abp.MultiTenancy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MellowWoodProject.CMS.Dto
{

    public class CMSInfoDto
    {
        [Required]
        public int id { get; set; }

        [Required]
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        public string pageName { get; set; }

        [Required]
        [StringLength(1500)]
        public string pageContent { get; set; }


    }

}
