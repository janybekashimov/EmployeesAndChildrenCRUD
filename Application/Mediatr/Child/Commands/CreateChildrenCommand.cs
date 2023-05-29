using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Child.Commands
{
    public class CreateChildrenCommand : IRequest<Children>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public class CreateChildrenCommandHandler : IRequestHandler<CreateChildrenCommand, Children>
        {
            private readonly IApplicationDbContext _context;
            private readonly ILogger<CreateChildrenCommandHandler> _logger;

            public CreateChildrenCommandHandler(IApplicationDbContext context, ILogger<CreateChildrenCommandHandler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<Children> Handle(CreateChildrenCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var children = new Children()
                    {
                        Id = command.Id,
                        LastName = command.LastName,
                        Name = command.Name,
                        MiddleName = command.MiddleName,
                        BirthDate = command.BirthDate,
                        EmployeeId = command.EmployeeId,
                    };
                    _context.Children.Add(children);
                    await _context.SaveChangesAsync(cancellationToken);
                    return children;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, "Произошла ошибка при создании!");
                    return null;
                }
            }
        }
    }
}