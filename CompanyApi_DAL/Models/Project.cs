using MessagePack;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Model
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectLeader { get; set; }
        public string Language { get; set; }

        //[JsonIgnore]
        public virtual ICollection<EmployeeProject>? employeeProjects { get; set; }
    }
}
