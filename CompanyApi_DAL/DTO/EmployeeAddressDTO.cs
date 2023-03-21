using EmployeeApi.Model;
using System.ComponentModel.DataAnnotations;

namespace CompanyApi.DTO
{
    public class EmployeeAddressDTO
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public int DeptId { get; set; }
        public int? TeamId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string city { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
