using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApi.Model
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamLeader { get; set; }

        [JsonIgnore]
        public virtual ICollection<Employee>? Employees { get; set; }

    }
}
