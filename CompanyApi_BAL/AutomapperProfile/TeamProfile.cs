using AutoMapper;
using CompanyApi.DTO;
using EmployeeApi.Model;

namespace CompanyApi.AutomapperProfile
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<Team, TeamDTO>().ReverseMap();
            CreateMap<UpdateTeamDTO, Team>().ReverseMap();
        }
    }
}
