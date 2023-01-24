using Employees.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Services
{
    public interface IDropDownSelectService
    {
        Task<IEnumerable<Employee>> GetDropDownEmployeesList();
    }
}