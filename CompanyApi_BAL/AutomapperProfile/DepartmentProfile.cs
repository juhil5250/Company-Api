using AutoMapper;
using CompanyApi.DTO;
using EmployeeApi.Model;

namespace CompanyApi.AutomapperProfile
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<UpdateDepartmentDTO, Department>().ReverseMap();
        }
    }
}
