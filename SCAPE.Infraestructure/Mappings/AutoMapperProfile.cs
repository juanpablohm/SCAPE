using AutoMapper;
using SCAPE.Application.DTOs;
using SCAPE.Domain.Entities;

namespace SCAPE.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
        }
       
    }
}
