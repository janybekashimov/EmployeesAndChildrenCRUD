using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Employ.Commands
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
            private readonly IApplicationDbContext _context;
            private readonly ILogger<CreateEmployeeCommandHandler> _logger;

            public CreateEmployeeCommandHandler(IApplicationDbContext context, ILogger<CreateEmployeeCommandHandler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Employee> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var employee = new Employee()
                    {
                        LastName = command.LastName,
                        Name = command.Name,
                        MiddleName = command.MiddleName,
                        BirthDate = command.BirthDate,
                        Position = command.Position
                    };

                    _context.Employees.Add(employee);
                    await _context.SaveChangesAsync(cancellationToken);
                    return employee;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, "Произошла ошибка при создании записи!");
                    return null;
                }
            }
        }
    }
}