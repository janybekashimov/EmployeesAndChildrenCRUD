using Employees.Data;
using Employees.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<int> DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            return await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeesById(int id)
        {
            return await _context.Employees.Include(x => x.Children).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesList()
        {
            return await _context.Employees.Include(x => x.Children).ToListAsync();
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync();
        }
    }
}