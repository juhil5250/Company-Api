using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApi.Model
{
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        [Key]
        public int DeptId { get; set; }
        public string Name { get; set; }


        [JsonIgnore]
        public virtual ICollection<Employee>? Employees { get; set; }

    }
}
