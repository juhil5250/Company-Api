using CompanyApi.DTO;

namespace CompanyApi_Test.Mockdata
{
    public class EmployeeMockData
    {
        public static async Task<List<EmployeeDto>> GetEmployee()
        {
            return new List<EmployeeDto>()
            {
                new EmployeeDto()
                {
                    Name = "juhil",
                    Email = "juhil@gmail.com",
                    Age = 20,
                    ContactNo = "9173230023",
                    Gender = "Male",
                    DeptId = 1,
                    TeamId = 1,
                },
                new EmployeeDto()
                {
                    Name = "akhil",
                    Email = "akhil@gmail.com",
                    Age = 22,
                    ContactNo = "1020102100",
                    Gender = "Male",
                    DeptId = 2,
                    TeamId = 2,
                },
                new EmployeeDto()
                {
                    Name = "Darshan",
                    Email = "darshan@gmail.com",
                    Age = 23,
                    ContactNo = "1212211212",
                    Gender = "Male",
                    DeptId = 2,
                    TeamId = 3,
                },
            };
        }
    }
}
