using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApi.Model
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public DateTime? DateofBirth { get; set; } = DateTime.Now;
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? TeamId { get; set; }


        [ForeignKey(nameof(DeptId))]
        [JsonIgnore]
        public virtual Department? Department { get; set; }


        [JsonIgnore]
        public virtual ICollection<EmployeeAddress>? EmployeeAddress { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(TeamId))]
        public virtual Team? Team { get; set; }

        //[JsonIgnore]
        public virtual ICollection<EmployeeProject>? employeeprojects { get; set; }
    }
}

