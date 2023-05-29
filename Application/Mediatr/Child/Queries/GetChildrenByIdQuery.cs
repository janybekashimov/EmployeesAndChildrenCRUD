using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Child.Queries
{
    public class GetChildrenByIdQuery : IRequest<Children>
    {
        public int Id { get; set; }
    }
    public class GetChildrenByIdQueryHandler : IRequestHandler<GetChildrenByIdQuery, Children>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetChildrenByIdQueryHandler> _logger;

        public GetChildrenByIdQueryHandler(IApplicationDbContext context, ILogger<GetChildrenByIdQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Children> Handle(GetChildrenByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Children.Include(x => x.Employee).FirstOrDefaultAsync(x => x.Id == query.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Произошла ошибка при выводе записи по Id");
                return null;
            }
        }
    }
}