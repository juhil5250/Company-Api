namespace CompanyApi.DTO
{
    public class AddEmployeeAddressDTO
    {
        public int EmpID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string city { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
