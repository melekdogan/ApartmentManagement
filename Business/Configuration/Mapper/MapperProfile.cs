using AutoMapper;
using DTOs.User;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Configuration.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Apartment Maps

            #endregion

            #region Invoice Maps

            #endregion

            #region InvoiceType Maps

            #endregion

            #region Tenant Maps

            #endregion          
           
            #region UserMaps 
            CreateMap<User, CreateUserRequestDTO>();
            #endregion
  
            #region UserRole Maps

            #endregion

            #region Vehicle Maps

            #endregion
            
        }
    }
}
