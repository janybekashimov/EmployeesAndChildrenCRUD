using Employees.Models;
using Employees.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Features.Employ.Queries
{
    public class GetAllEmploeesQuery : IRequest<IEnumerable<Employee>>
    {
        public class GetAllPlayersQueryHandler : IRequestHandler<GetAllEmploeesQuery, IEnumerable<Employee>>
        {
            private readonly IEmployeeService _employeeService;

            public GetAllPlayersQueryHandler(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }

            public Task<IEnumerable<Employee>> Handle(GetAllEmploeesQuery query, CancellationToken cancellationToken)
            {
                return _employeeService.GetEmployeesList();
            }
        }
    }
}