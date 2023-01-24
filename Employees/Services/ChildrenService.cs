using Employees.Data;
using Employees.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Services
{
    public class ChildrenService : IChildrenService
    {
        private readonly ApplicationDbContext _context;

        public ChildrenService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Children> CreateChildren(Children children)
        {
            _context.Children.Add(children);
            await _context.SaveChangesAsync();
            return children;
        }

        public async Task<int> DeleteChildren(Children children)
        {
            _context.Children.Remove(children);
            return await _context.SaveChangesAsync();
        }

        public async Task<Children> GetChildrenById(int id)
        {
            return await _context.Children.Include(x => x.Employee).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Children>> GetChildrenList()
        {
            return await _context.Children.Include(x => x.Employee).ToListAsync();
        }

        public async Task<int> UpdateChildren(Children children)
        {
            _context.Children.Update(children);
            return await _context.SaveChangesAsync();
        }
    }
}