using Employees.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Features.Employ.Commands
{
    public class UpdateEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }

        public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, int>
        {
            private readonly IEmployeeService _employeeService;

            public UpdateEmployeeCommandHandler(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }

            public async Task<int> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
            {
                var employee = await _employeeService.GetEmployeesById(command.Id);
                if (employee == null)
                {
                    return default;
                }
                employee.LastName = command.LastName;
                employee.Name = command.Name;
                employee.BirthDate = command.BirthDate;
                employee.Position = command.Position;

                return await _employeeService.UpdateEmployee(employee);
            }
        }
    }
}