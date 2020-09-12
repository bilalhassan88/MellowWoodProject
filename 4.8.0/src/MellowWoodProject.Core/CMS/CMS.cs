using Abp.MultiTenancy;
using MellowWoodProject.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace MellowWoodProject.CMS
{
    public class CMS : Entity
    {
        public string pageName { get; set; }
        [MaxLength(1500)]
        public string pageContent { get; set; }


    }
}
