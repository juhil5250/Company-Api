﻿using AutoMapper;
using CompanyApi.Context;
using CompanyApi.DTO;
using CompanyApi.Interface;
using CompanyApi_DAL.Models;
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

        
        public async Task<EmployeeResponse> GetEmployees(int page, float pageResult)
        {
            if(_context.Employee == null)
            {
                throw new Exception("Employee Not found");
            }

            
            var pageCount = Math.Ceiling(_context.Employee.Count() / pageResult);

            var result = await _context.Employee
                        .Include(e => e.Department)
                        .Include(e => e.EmployeeAddress)
                        .Include(e => e.employeeprojects)
                        .Skip((page - 1) * (int)pageResult)
                        .Take((int)pageResult)
                        .ToListAsync();

            var employeeResponse = new EmployeeResponse()
            {
                employees = result,
                Pages = (int)pageCount,
                CurrentPage = page
            };

            return employeeResponse;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            if (_context == null)
            {
                return null;
            }

            var result = await _context.Employee.Where(e => e.EmpId == id).Include(d => d.Department).Include(e => e.EmployeeAddress).Include(e => e.employeeprojects).FirstOrDefaultAsync();

            ArgumentNullException.ThrowIfNull(result, "User Not Found");

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
