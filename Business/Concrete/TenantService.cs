using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.EntityFrameworkCoreBase;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TenantService : ITenantService
    {
        public Tenant Add(Tenant entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Tenant entity)
        {
            throw new NotImplementedException();
        }

        public Tenant Get(Expression<Func<Tenant, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tenant> GetAll(Expression<Func<Tenant, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Tenant Update(Tenant entity)
        {
            throw new NotImplementedException();
        }
    }
}
