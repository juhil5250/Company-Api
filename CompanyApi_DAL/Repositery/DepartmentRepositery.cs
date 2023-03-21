using CompanyApi.Context;
using CompanyApi_DAL.Interface;
using EmployeeApi.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi_DAL.Repositery
{
    public class DepartmentRepositery : IDepartmentRepositery
    {
        private readonly CompanyContext _context;

        public DepartmentRepositery(CompanyContext context)
        {
            _context = context;
        }

        public async Task<Department> AddDepartment(Department department)
        {
            _context.Department.Add(department);

            return department;
        }

        public async Task<Department> DeleteDepartment(int id)
        {
            if(_context == null)
            {
                return null;
            }

            var department = await _context.Department.FindAsync(id);

            _context.Department.Remove(department);

            return department;

        }

        public Task<Department> GetDepartmentById(int id)
        {
            if(_context == null)
            {
                return null;
            }

            var employee = _context.Department.Where(x => x.DeptId == id).Include(x => x.Employees).FirstOrDefaultAsync();

            return employee;
        }

        public async Task<List<Department>> GetDepartments()
        {
            if(_context == null)
            {
                return null;
            }

            var employee = await _context.Department.ToListAsync();

            return employee;
        }

        public async Task saveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            if(_context == null)
            {
                return null;
            }

            _context.Entry(department).State = EntityState.Modified;

            return department;
        }
    }
}
