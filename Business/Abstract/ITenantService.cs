using Business.Abstract.BaseService;
using DataAccess.Abstract;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITenantService:IBaseService<Tenant>
    {
    }
}
