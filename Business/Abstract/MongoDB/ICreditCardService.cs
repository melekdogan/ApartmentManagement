using Models.Document;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.MongoDB
{
    public interface ICreditCardService
    {
        void Add(CreditCard model);
        void Update(CreditCard model);
        void Delete(ObjectId id);
        CreditCard Get(ObjectId id);
        IEnumerable<CreditCard> GetAll();
        void TestExceptionFilter();
    }
}
