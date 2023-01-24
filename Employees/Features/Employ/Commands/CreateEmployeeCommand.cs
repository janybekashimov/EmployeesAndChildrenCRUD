using Employees.Models;
using Employees.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Features.Employ.Commands
{
    public class CreateEmployeeCommand : IRequest<Employee>
    {
        public string LastName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }

        public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
        {
            private readonly IEmployeeService _employeeService;

            public CreateEmployeeCommandHandler(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }

            public async Task<Employee> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
            {
                var employee = new Employee()
                {
                    LastName = command.LastName,
                    Name = command.Name,
                    MiddleName = command.MiddleName,
                    BirthDate = command.BirthDate,
                    Position = command.Position
                };

                return await _employeeService.CreateEmployee(employee);
            }
        }
    }
}