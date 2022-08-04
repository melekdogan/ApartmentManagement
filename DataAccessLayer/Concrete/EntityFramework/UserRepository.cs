using DataAccess.Abstract;
using DataAccess.DBContexts;
using DataAccess.EntityFrameworkCoreBase;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class UserRepository : EntityRepositoryBase<ApartmentManagementDBContext
        , User>, IUserRepository
    {
        public UserRepository(ApartmentManagementDBContext dbContext) : base(dbContext)
        {
        }
    }
}
