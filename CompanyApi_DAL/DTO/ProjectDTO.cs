using EmployeeApi.Model;

namespace CompanyApi.DTO
{
    public class ProjectDTO
    {
        public string ProjectName { get; set; }
        public string ProjectLeader { get; set; }
        public string Language { get; set; }

        public virtual List<EmployeeProject> EmployeeProjects { get; set; }
    }
}
