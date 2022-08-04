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
    public class InvoiceTypeService : IInvoiceTypeService
    {
        private readonly IInvoiceTypeRepository _repository;

        public InvoiceTypeService(IInvoiceTypeRepository repository)
        {
            _repository = repository;
        }

        public InvoiceType Add(InvoiceType invoiceType)
        {
            //Validation
            return _repository.Add(invoiceType);
        }

        public void Delete(InvoiceType invoiceType)
        {
            //Validation
            _repository.Delete(invoiceType);
        }

        public InvoiceType Get(Expression<Func<InvoiceType, bool>> expression)
        {
            //Validation
            return _repository.Get(expression);
        }

        public IEnumerable<InvoiceType> GetAll(Expression<Func<InvoiceType, bool>> expression = null)
        {
            //Validation
            return _repository.GetAll(expression);
        }

        public InvoiceType Update(InvoiceType invoiceType)
        {
            return _repository.Update(invoiceType);
        }
    }
}
