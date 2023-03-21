using CompanyApi.Context;
using CompanyApi_DAL.Interface;
using EmployeeApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi_DAL.Repositery
{
    public class EmployeeAddressRepositery : IEmployeeAddressRepositery
    {
        private readonly CompanyContext _context;
        
        public EmployeeAddressRepositery(CompanyContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeAddress>> GetEmployeeAddress()
        {
            if (_context == null)
            {
                return null;
            }

            var result = await _context.EmployeeAddresses.Include(e => e.Employee).ToListAsync();

            return result;
        }

        public async Task<EmployeeAddress> GetEmployeeAddressById(int id)
        {
            if (_context == null)
            {
                return null;
            }

            var result = await _context.EmployeeAddresses.Where(e => e.EmpId == id).Include(e => e.Employee).FirstOrDefaultAsync();

            return result;
        }

        public async Task<EmployeeAddress> AddEmployeeAddress(EmployeeAddress employeeAddress)
        {
            _context.EmployeeAddresses.Add(employeeAddress);

            return employeeAddress;
        }

        public async Task<EmployeeAddress> UpdateEmployeeAddress(EmployeeAddress employeeAddress)
        {
            if (_context == null)
            {
                return null;
            }

            _context.Entry(employeeAddress).State = EntityState.Modified;

            return employeeAddress;
        }

        public async Task<EmployeeAddress> DeleteEmployeeAddress(int id)
        {
            if (_context == null)
            {
                return null;
            }

            var empAdd = await _context.EmployeeAddresses.FindAsync(id);

            _context.EmployeeAddresses.Remove(empAdd);

            return empAdd;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
