using Newtonsoft.Json;

namespace EmployeeApi.Model
{
    public class EmployeeProject
    {
        public int EmpId { get; set; }
        public int ProjectId { get; set; }

        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
        [JsonIgnore]
        public virtual Project? Project { get; set; }
    }
}
