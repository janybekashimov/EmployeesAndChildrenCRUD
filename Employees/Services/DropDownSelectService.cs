using Employees.Data;
using Employees.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Services
{
    public class DropDownSelectService : IDropDownSelectService
    {
        private readonly ApplicationDbContext _context;

        public DropDownSelectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetDropDownEmployeesList()
        {
            IEnumerable<SelectListItem> EmployeeDropDown = _context.Employees.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });

            return await _context.Employees.ToListAsync();
        }
    }
}