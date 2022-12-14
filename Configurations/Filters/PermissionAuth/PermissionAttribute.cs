using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace Configurations.Filters.PermissionAuth
{
    public class PermissionAttribute : TypeFilterAttribute
    {
        public PermissionAttribute(Permission permission) : base(typeof(PermissionFilter))
        {
            Arguments = new object[] { permission };
        }
    }
}
