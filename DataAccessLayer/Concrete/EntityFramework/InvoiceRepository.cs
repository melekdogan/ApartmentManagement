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
    public class InvoiceRepository : EntityRepositoryBase<ApartmentManagementDBContext
        , Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(ApartmentManagementDBContext dbContext) : base(dbContext)
        {
        }
    }
}
