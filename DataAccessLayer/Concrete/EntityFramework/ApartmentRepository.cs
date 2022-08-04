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
    public class ApartmentRepository : EntityRepositoryBase<ApartmentManagementDBContext
        , Apartment>, IApartmentRepository
    {
        public ApartmentRepository(ApartmentManagementDBContext dbContext) : base(dbContext)
        {
        }
    }
}
