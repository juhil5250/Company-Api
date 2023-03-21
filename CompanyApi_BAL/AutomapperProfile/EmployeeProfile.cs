using AutoMapper;
using CompanyApi.DTO;
using EmployeeApi.Model;

namespace CompanyApi.AutomapperProfile
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<UpdateEmployeeDTO, Employee>().ReverseMap();
        }
    }
}
