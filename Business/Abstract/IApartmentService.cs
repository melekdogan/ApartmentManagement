using Configurations.Response;
using DTOs.Apartment;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApartmentService
    {
        public CommandResponse Add(CreateApartmentRequest request);
        public CommandResponse Update(UpdateApartmentRequest request);
        public CommandResponse Delete(DeleteApartmentRequest request);
        public IEnumerable<Apartment> GetAll();
    }
}
