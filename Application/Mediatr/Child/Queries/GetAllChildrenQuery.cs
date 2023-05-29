using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Child.Queries
{
    public class GetAllChildrenQuery : IRequest<IEnumerable<Children>>
    {
    }
    public class GetAllChildrenQueryHandler : IRequestHandler<GetAllChildrenQuery, IEnumerable<Children>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetAllChildrenQueryHandler> _logger;

        public GetAllChildrenQueryHandler(IApplicationDbContext context, ILogger<GetAllChildrenQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Children>> Handle(GetAllChildrenQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Children.Include(x => x.Employee).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Произошла ошибка при выводе данных!");
                return null;
            }
        }
    }
    
}