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
    public class InvoiceService : IInvoiceService
    {
        private IInvoiceRepository _repository;

        public InvoiceService(IInvoiceRepository repository)
        {
            _repository = repository;
        }

        public Invoice Add(Invoice invoice)
        {
            return _repository.Add(invoice);
        }

        public void Delete(Invoice invoice)
        {
            _repository.Delete(invoice);
        }

        public Invoice Get(Expression<Func<Invoice, bool>> expression)
        {
            return _repository.Get(expression);
        }

        public IEnumerable<Invoice> GetAll(Expression<Func<Invoice, bool>> expression = null)
        {
            return _repository.GetAll(expression);
        }

        public Invoice Update(Invoice invoice)
        {
            return _repository.Update(invoice);
        }
    }
}
