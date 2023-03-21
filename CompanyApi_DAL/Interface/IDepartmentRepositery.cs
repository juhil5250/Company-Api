using EmployeeApi.Model;

namespace CompanyApi_DAL.Interface
{
    public interface IDepartmentRepositery
    {
        Task<List<Department>> GetDepartments();
        Task<Department> GetDepartmentById(int id);
        Task<Department> AddDepartment(Department Department);
        Task<Department> UpdateDepartment(Department Department);
        Task<Department> DeleteDepartment(int id);
        Task saveAsync();
    }
}
