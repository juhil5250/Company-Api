using AutoMapper;
using CompanyApi.Context;
using CompanyApi.DTO;
using CompanyApi.Interface;
using EmployeeApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CompanyApi.Repositery
{
    public class EmployeeRepositery : IEmployeeRepositery
    {
        private readonly CompanyContext _context;

        public EmployeeRepositery(CompanyContext Context)
        {
            _context = Context;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            if(_context == null)
            {
                return null;
            }

            var result = await _context.Employee.Include(e => e.Department).Include(e => e.EmployeeAddress).Include(e => e.employeeprojects).ToListAsync();

            return result;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            if (_context == null)
            {
                return null;
            }

            var result = await _context.Employee.Where(e => e.EmpId == id).Include(d => d.Department).Include(e => e.EmployeeAddress).Include(e => e.employeeprojects).FirstOrDefaultAsync();

            return result;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            _context.Employee.Add(employee);

            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            if (_context == null)
            {
                return null;
            }

            _context.Entry(employee).State= EntityState.Modified;

            return employee;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            if (_context == null)
            {
                return null;
            }

            var employee = await _context.Employee.FindAsync(id);

            _context.Employee.Remove(employee);

            return employee;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
