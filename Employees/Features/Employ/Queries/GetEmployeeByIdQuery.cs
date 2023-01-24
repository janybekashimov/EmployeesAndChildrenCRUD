using Employees.Models;
using Employees.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Features.Employ.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }

        public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
        {
            private readonly IEmployeeService _employeeService;

            public GetEmployeeByIdQueryHandler(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }

            public async Task<Employee> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
            {
                return await _employeeService.GetEmployeesById(query.Id);
            }
        }
    }
}