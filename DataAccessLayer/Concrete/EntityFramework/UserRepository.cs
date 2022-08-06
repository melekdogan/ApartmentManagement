using DataAccess.Abstract;
using DataAccess.DBContexts;
using DataAccess.EntityFrameworkCoreBase;
using Microsoft.EntityFrameworkCore;
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

        //Parametredeki email ile veritabanında emaili eşleşen kullanıcıyı şifresiyle beraber alıyoruz.
        public User GetUserWithPassword(string email)
        {
            return _dbContext.Users
                .Include(x => x.Password)
                .FirstOrDefault(x => x.EMail == email);
        }
    }
}
