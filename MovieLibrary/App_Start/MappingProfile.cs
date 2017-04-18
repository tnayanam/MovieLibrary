using AutoMapper;
using MovieLibrary.Dtos;
using MovieLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieLibrary.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}