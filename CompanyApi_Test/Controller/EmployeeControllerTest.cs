using AutoMapper;
using CompanyApi.DTO;
using CompanyApi_BAL.Services.IServices;
using CompanyApi_Test.Mockdata;
using EmployeeApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace CompanyApi_Test.Controller
{
    public class EmployeeControllerTest
    {
        private readonly Mock<ILogger<EmployeeController>> _logger;
        private readonly IMapper _mapper;
        private readonly Mock<IEmployeeServices> _employeeServices;

        public EmployeeControllerTest()
        {
            _employeeServices = new Mock<IEmployeeServices>();
            var myprofile = new CompanyApi.AutomapperProfile.EmployeeProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myprofile));
            _mapper = new Mapper(configuration);
            _logger = new Mock<ILogger<EmployeeController>>();
        }

        [Fact]
        public async Task EmployeeController_GetEmployee_IsEmptyorNot()
        {
            //Arrange
            var employee = EmployeeMockData.GetEmployee();
            var result = _mapper.Map<List<EmployeeDto>>(employee);
            _employeeServices.Setup(_ => _.GetEmployee()).Returns();
            var controller = new EmployeeController((CompanyApi_BAL.Services.EmployeeServices)_employeeServices.Object);

            //Act
            var EmployeeResult = await controller.GetEmployee();

            //Assert
            Assert.NotNull(EmployeeResult);
            //Assert.False(EmployeeResult.Equals(GetEmployee()));
        }

        [Fact]
        public async Task EmployeeController_GetEmployeeById_ReturnStatusCode200()
        {
            //Arrange
            var employee = EmployeeMockData.GetEmployee();
            _employeeServices.Setup(_ => _.GetEmployeeById(1).Result).Returns(employee[0]);
            EmployeeController controller = new EmployeeController((CompanyApi_BAL.Services.EmployeeServices)_employeeServices.Object);

            //Act
            var result = await controller.GetEmployeeById(1);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task EmployeeController_GetEmployeeById_ReturnStatusCode404()
        {
            var employee = EmployeeMockData.GetEmployee();
            //Arrange
            _employeeServices.Setup(_ => _.GetEmployeeById(4).Result).Returns(employee[2]);
            EmployeeController controller = new EmployeeController((CompanyApi_BAL.Services.EmployeeServices)_employeeServices.Object);

            //Act
            var result = await controller.GetEmployeeById(2);

            //Assert
            //var EmptyResult = result as NotFoundResult;
            //Assert.Equal(404, EmptyResult.StatusCode);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
