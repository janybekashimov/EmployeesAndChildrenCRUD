using Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Employ.Commands
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
            private readonly IApplicationDbContext _context;
            private readonly ILogger<UpdateEmployeeCommandHandler> _logger;

            public UpdateEmployeeCommandHandler(IApplicationDbContext context, ILogger<UpdateEmployeeCommandHandler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<int> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var employee = await _context.Employees.FindAsync(command.Id);
                    if (employee == null)
                    {
                        return 0;
                    }
                    employee.LastName = command.LastName;
                    employee.Name = command.Name;
                    employee.BirthDate = command.BirthDate;
                    employee.Position = command.Position;

                    await _context.SaveChangesAsync(cancellationToken);
                    return command.Id;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, "Произошла ошибка при обновлении записи!");
                    return 0;
                }
            }
        }
    }
}