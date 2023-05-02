using AutoMapper;
using CompanyApi.DTO;
using CompanyApi_DAL.DTO;
using CompanyApi_DAL.Models;
using EmployeeApi.Model;

namespace CompanyApi.AutomapperProfile
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<UpdateEmployeeDTO, Employee>().ReverseMap();
            CreateMap<EmployeeResponse, EmployeeResponseDto>().ReverseMap();
        }
    }
}
