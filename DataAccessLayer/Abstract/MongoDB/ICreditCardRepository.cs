using DAL.MongoBase;
using Models.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract.MongoDB
{
    public interface ICreditCardRepository:IDocumentRepository<CreditCard>
    {
    }
}
