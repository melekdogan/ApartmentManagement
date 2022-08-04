using Business.Abstract;
using DataAccess.Abstract;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserRoleService : IUserRoleService
    {
        protected readonly IUserRoleRepository _repository;

        public UserRoleService(IUserRoleRepository repository)
        {
            _repository = repository;
        }

        public UserRole Add(UserRole entity)
        {
            return _repository.Add(entity);
        }

        public void Delete(UserRole entity)
        {
            _repository.Delete(entity);
        }

        public UserRole Get(Expression<Func<UserRole, bool>> expression)
        {
            return _repository.Get(expression);
        }

        public IEnumerable<UserRole> GetAll(Expression<Func<UserRole, bool>> expression = null)
        {
            return _repository.GetAll(expression);
        }

        public UserRole Update(UserRole entity)
        {
            return _repository.Update(entity);
        }
    }
}
