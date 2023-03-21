using AutoMapper;
using CompanyApi.DTO;
using EmployeeApi.Model;

namespace CompanyApi.AutomapperProfile
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<UpdateProjectDTO, Project>().ReverseMap();
        }
    }
}
