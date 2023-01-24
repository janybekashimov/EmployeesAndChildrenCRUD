using Employees.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Services
{
    public interface IChildrenService
    {
        Task<IEnumerable<Children>> GetChildrenList();

        Task<Children> GetChildrenById(int id);

        Task<Children> CreateChildren(Children children);

        Task<int> UpdateChildren(Children children);

        Task<int> DeleteChildren(Children children);
    }
}