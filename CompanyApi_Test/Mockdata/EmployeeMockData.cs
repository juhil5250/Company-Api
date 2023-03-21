using EmployeeApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi_Test.Mockdata
{
    public class EmployeeMockData
    {
        public static List<Employee> GetEmployee()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    EmpId = 1,
                    Name = "juhil",
                    Email = "juhil@gmail.com",
                    Age = 20,
                    ContactNo = "9173230023",
                    Gender = "Male",
                    DeptId = 1,
                    TeamId = 1,
                },
                new Employee()
                {
                    EmpId = 2,
                    Name = "akhil",
                    Email = "akhil@gmail.com",
                    Age = 22,
                    ContactNo = "1020102100",
                    Gender = "Male",
                    DeptId = 2,
                    TeamId = 2,
                },
                new Employee()
                {
                    EmpId = 3,
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
