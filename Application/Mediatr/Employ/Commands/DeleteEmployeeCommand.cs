using Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Employ.Commands
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, int>
        {
            private readonly IApplicationDbContext _context;
            private readonly ILogger<DeleteEmployeeCommandHandler> _logger;

            public DeleteEmployeeCommandHandler(IApplicationDbContext context, ILogger<DeleteEmployeeCommandHandler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<int> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var employee = await _context.Employees.FindAsync(command.Id);
                    if (employee == null)
                    {
                        return 0;
                    }

                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync(cancellationToken);
                    return command.Id;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, "Произошла ошибка при удалении записи!");
                    return 0;
                }
            }
        }
    }
}