using DAL.MongoBase;
using DataAccess.Abstract.MongoDB;
using Microsoft.Extensions.Configuration;
using Models.Document;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.MongoDB
{
    public class CreditCardRepository : DocumentRepository<CreditCard>, ICreditCardRepository
    {
        private const string _collectionName = "CreditCard";
        public CreditCardRepository(MongoClient client, IConfiguration configuration, string collectionName) : base(client, configuration, _collectionName)
        {
        }
    }
}
