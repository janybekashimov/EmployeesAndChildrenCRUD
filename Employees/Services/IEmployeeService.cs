using Employees.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesList();

        Task<Employee> GetEmployeesById(int id);

        Task<Employee> CreateEmployee(Employee employee);

        Task<int> UpdateEmployee(Employee employee);

        Task<int> DeleteEmployee(Employee employee);
    }
}