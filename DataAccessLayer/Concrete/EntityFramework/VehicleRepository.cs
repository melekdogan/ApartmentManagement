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
    public class VehicleRepository : EntityRepositoryBase<ApartmentManagementDBContext
        , Vehicle>, IVehicleRepository
    {
        public VehicleRepository(ApartmentManagementDBContext dbContext) : base(dbContext)
        {
        }
    }
}
