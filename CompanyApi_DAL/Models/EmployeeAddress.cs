using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EmployeeApi.Model
{
    public class EmployeeAddress
    {
        [Key, ForeignKey("Employee")]
        public int EmpId { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string city { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        [JsonIgnore]
        public virtual Employee? Employee { get; set; }
    }
}
