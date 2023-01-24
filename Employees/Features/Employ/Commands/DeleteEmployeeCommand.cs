using Employees.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Features.Employ.Commands
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, int>
        {
            private readonly IEmployeeService _employeeService;

            public DeleteEmployeeCommandHandler(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }

            public async Task<int> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
            {
                var employee = await _employeeService.GetEmployeesById(command.Id);
                if (employee == null)
                {
                    return default;
                }
                return await _employeeService.DeleteEmployee(employee);
            }
        }
    }
}