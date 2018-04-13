using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DM = AQR.DomainModels;
using DE = AQR.DataEntities;

namespace AQR.DataMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DE.User, DM.User>()
                    .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.UserId))
                    .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.UserFirstName))
                    .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.UserLastName))
                    .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.Password))
                    .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.City))
                     //.ForMember(dest => dest.Department, opts => opts.MapFrom(src => new DM.Department { DepartmentId = src.DepartmentId, DepartmentName = src.Department }))
                    .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.Gender));

                cfg.CreateMap<DM.User, DE.User>()
                    .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.UserId))
                    .ForMember(dest => dest.UserFirstName, opts => opts.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.UserLastName, opts => opts.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.Password, opts => opts.MapFrom(src => src.Password))
                    .ForMember(dest => dest.City, opts => opts.MapFrom(src => src.City))
                     //.ForMember(dest => dest.Department, opts => opts.MapFrom(src => new DM.Department { DepartmentId = src.DepartmentId, DepartmentName = src.Department }))
                    .ForMember(dest => dest.Gender, opts => opts.MapFrom(src => src.Gender));

                cfg.CreateMap<DE.Department, DM.Department>()
                   .ForMember(dest => dest.DepartmentId, opts => opts.MapFrom(src => src.DepartmentID))
                   .ForMember(dest => dest.DepartmentName, opts => opts.MapFrom(src => src.Name));

                cfg.CreateMap<DM.Department, DE.Department>()
                   .ForMember(dest => dest.DepartmentID, opts => opts.MapFrom(src => src.DepartmentId))
                   .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.DepartmentName));
            });
        }
    }
}
