using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IInvoiceService
    {
        Invoice Add(Invoice invoice);
        Invoice Update(Invoice invoice);
        void Delete(Invoice invoice);
        IEnumerable<Invoice> GetAll(Expression<Func<Invoice, bool>> expression = null);
        Invoice Get(Expression<Func<Invoice, bool>> expression);
    }
}
