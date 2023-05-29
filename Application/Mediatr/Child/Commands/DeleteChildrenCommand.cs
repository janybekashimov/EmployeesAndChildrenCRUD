using Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Child.Commands
{
    public class DeleteChildrenCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteChildrenCommandHandler : IRequestHandler<DeleteChildrenCommand, int>
        {
            private readonly IApplicationDbContext _context;
            private readonly ILogger<DeleteChildrenCommandHandler> _logger;

            public DeleteChildrenCommandHandler(IApplicationDbContext context, ILogger<DeleteChildrenCommandHandler> logger)
            {
                _context = context;
                _logger = logger;
            }

            public async Task<int> Handle(DeleteChildrenCommand command, CancellationToken cancellationToken)
            {
                try
                {
                    var children = await _context.Children.FindAsync(command.Id);
                    if (children == null)
                    {
                        return 0;
                    }
                    _context.Children.Remove(children);
                    await _context.SaveChangesAsync(cancellationToken);
                    return command.Id;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message, "Произошла ошибка при удалении!");
                    return 0;
                }
            }
        }
    }
}