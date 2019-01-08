using AutoMapper;
using NetCoreUsingVsCode.DTO;
using NetCoreUsingVsCode.Models;

namespace NetCoreUsingVsCode.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // configuration for Mapper
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}