//using AutoMapper;
//using CompanyApi.DTO;
//using CompanyApi_BAL.Services.IServices;
//using CompanyApi_Test.Mockdata;
//using EmployeeApi.Controllers;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Moq;

//namespace CompanyApi_Test.Controller
//{
//    public class EmployeeControllerTest
//    {
//        private readonly Mock<ILogger<EmployeeController>> _logger;
//        private readonly Mock<IMapper> _mapper;
//        private readonly Mock<IEmployeeServices> _employeeServices;

//        public EmployeeControllerTest()
//        {
//            _employeeServices = new Mock<IEmployeeServices>();
//            _mapper = new Mock<IMapper>();
//            _logger = new Mock<ILogger<EmployeeController>>();
//        }

//        [Fact]
//        public async Task EmployeeController_GetEmployee_IsEmptyorNot()
//        {
//            //Arrange
//            var employee = EmployeeMockData.GetEmployee();
//            _employeeServices.Setup(_ => _.GetEmployee()).Returns(employee);
//            var controller = new EmployeeController(_employeeServices.Object);

//            //Act
//            var result = await controller.GetEmployee();

//            //Assert
//            var obj = result as ObjectResult;
//            Assert.Equal(200, obj?.StatusCode);
//        }

//        [Fact]
//        public async Task EmployeeController_GetEmployeeById_ReturnStatusCode200()
//        {
//            //Arrange
//            var employee = EmployeeMockData.GetEmployee();
//            _employeeServices.Setup(_ => _.GetEmployeeById(1).Result).Returns((await employee)[0]);
//            var controller = new EmployeeController((CompanyApi_BAL.Services.EmployeeServices)_employeeServices.Object);

//            //Act
//            var result = await controller.GetEmployeeById(1);

//            //Assert
//            var obj = result as ObjectResult;
//            Assert.Equal(200, obj?.StatusCode);
//        }

//        [Fact]
//        public async Task EmployeeController_GetEmployeeById_ReturnStatusCode404()
//        {
//            var employee = EmployeeMockData.GetEmployee();
//            //Arrange
//            _employeeServices.Setup(_ => _.GetEmployeeById(4).Result).Returns((await employee)[2]);
//            EmployeeController controller = new EmployeeController((CompanyApi_BAL.Services.EmployeeServices)_employeeServices.Object);

//            //Act
//            var result = await controller.GetEmployeeById(2);

//            //Assert
//            //var EmptyResult = result as NotFoundResult;
//            //Assert.Equal(404, EmptyResult.StatusCode);
//            Assert.IsType<NotFoundResult>(result);
//        }
//    }
//}
