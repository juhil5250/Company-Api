using AutoMapper;
using CompanyApi.DTO;
using EmployeeApi.Model;

namespace CompanyApi.AutomapperProfile
{
    public class EmployeeAddreesProfile : Profile
    {
        public EmployeeAddreesProfile()
        {
            CreateMap<EmployeeAddress, EmployeeAddressDTO>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => src.Employee.Name))
                .ForMember(dest => dest.Age,
                opt => opt.MapFrom(src => src.Employee.Age))
                .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Employee.Email))
                .ForMember(dest => dest.ContactNo,
                opt => opt.MapFrom(src => src.Employee.ContactNo))
                .ForMember(dest => dest.Gender,
                opt => opt.MapFrom(src => src.Employee.Gender))
                .ForMember(dest => dest.DeptId,
                opt => opt.MapFrom(src => src.Employee.DeptId))
                .ForMember(dest => dest.TeamId,
                opt => opt.MapFrom(src => src.Employee.TeamId));

            CreateMap<AddEmployeeAddressDTO, EmployeeAddress>();
        }
    }
}
