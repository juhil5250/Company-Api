namespace CompanyApi.DTO
{
    public class UpdateEmployeeDTO
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public int DeptId { get; set; }
        public int? TeamId { get; set; }
    }
}
