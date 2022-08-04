using Business.Abstract;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ApartmentService : IApartmentService
    {
        public Apartment Add(Apartment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Apartment entity)
        {
            throw new NotImplementedException();
        }

        public Apartment Get(Expression<Func<Apartment, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Apartment> GetAll(Expression<Func<Apartment, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Apartment Update(Apartment entity)
        {
            throw new NotImplementedException();
        }
    }
}
