using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserRoleService
    {
        UserRole Add(UserRole entity);
        UserRole Update(UserRole entity);
        void Delete(UserRole entity);
        IEnumerable<UserRole> GetAll(Expression<Func<UserRole, bool>> expression = null);
        UserRole Get(Expression<Func<UserRole, bool>> expression);
    }
}
