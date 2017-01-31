using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using vidly.Models;
using vidly.Dtos;


namespace vidly.App_Start
{
    public class MappingProfile: Profile 
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            //Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Movies, MovieDto>();


            Mapper.CreateMap<CustomerDto, Customer>()
               .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movies>()
                .ForMember(c => c.id, opt => opt.Ignore());
           
        
        }
        

    }
}