using AutoMapper;
using Business.Abstract;
using BusinessLayer.Configuration.Response;
using DataAccess.Abstract;
using DTOs.Apartment;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public ApartmentService(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        public CommandResponse Add(CreateApartmentRequest request)
        {
            var mapped = _mapper.Map<Apartment>(request);
            _apartmentRepository.Add(mapped);
            _apartmentRepository.SaveChanges();
            return new CommandResponse()
            {
                Status = true,
                Message = "Daire başarıyla kaydedildi!"
            };
        }

        public CommandResponse Delete(DeleteApartmentRequest request)
        {
            var mapped = _mapper.Map<Apartment>(request);
            _apartmentRepository.Delete(mapped);
            _apartmentRepository.SaveChanges();
            return new CommandResponse()
            {
                Status = true,
                Message = "Daire kaydı başarıyla silindi!"
            };
        }

        public IEnumerable<Apartment> GetAll()
        {
           return _apartmentRepository.GetAll();
        }

        public CommandResponse Update(UpdateApartmentRequest request)
        {
            var mapped = _mapper.Map<Apartment>(request);
            _apartmentRepository.Update(mapped);
            _apartmentRepository.SaveChanges();
            return new CommandResponse()
            {
                Status = true,
                Message = "Daire başarıyla Güncellendi!"
            };
        }
    }
}
