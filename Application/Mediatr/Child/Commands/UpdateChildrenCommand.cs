using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Child.Commands
{
    public class UpdateChildrenCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public class UpdateChildrenCommandHandler : IRequestHandler<UpdateChildrenCommand, int>
        {
            private readonly IApplicationDbContext _context;
            private readonly ILogger<UpdateChildrenCommandHandler> _logger;

            public UpdateChildrenCommandHandler(IApplicationDbContext context, ILogger<UpdateChildrenCommandHandler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<int> Handle(UpdateChildrenCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var children = await _context.Children.FindAsync(command.Id);
                    if (children == null)
                    {
                        return default;
                    }
                    children.LastName = command.LastName;
                    children.Name = command.Name;
                    children.MiddleName = command.MiddleName;
                    children.BirthDate = command.BirthDate;
                    children.EmployeeId = command.EmployeeId;

                    await _context.SaveChangesAsync(cancellationToken);
                    return command.Id;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, "Произошла ошибка при обновлении данных!");
                    return 0;
                }
            }
        }
    }
}