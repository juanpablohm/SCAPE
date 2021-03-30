using AutoMapper;
using SCAPE.Domain.DTOs;
using SCAPE.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCAPE.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<EmployeeDTO, Employee>();
    }
}
