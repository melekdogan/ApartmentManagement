using AutoMapper;
using DTOs.Apartment;
using DTOs.User;
using DTOs.Vehicle;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurations.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Apartment Maps
            CreateMap<Apartment, CreateApartmentRequest>();
            CreateMap<CreateApartmentRequest, Apartment>();
            CreateMap<Apartment, UpdateApartmentRequest>();
            CreateMap<UpdateApartmentRequest, Apartment>();
            CreateMap<Apartment, DeleteApartmentRequest>();
            CreateMap<DeleteApartmentRequest, Apartment>();
            #endregion

            #region Invoice Maps

            #endregion

            #region InvoiceType Maps

            #endregion

            #region Tenant Maps

            #endregion

            #region User Maps 
            CreateMap<User, CreateUserRequest>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<User, UpdateUserRequest>();
            CreateMap<DeleteUserRequest, User>();
            CreateMap<User, DeleteUserRequest>();
            CreateMap<CreateUserRequest, User>();

            #endregion

            #region Vehicle Maps
            CreateMap<CreateVehicleRequest, Vehicle>();
            CreateMap<Vehicle, CreateVehicleRequest>();
            CreateMap<GetVehicleResponse, Vehicle>();
            CreateMap<Vehicle, GetVehicleResponse>();
            #endregion

        }
    }
}
