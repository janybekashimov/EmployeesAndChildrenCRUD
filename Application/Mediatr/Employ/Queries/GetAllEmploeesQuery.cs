using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Employ.Queries
{
    public class GetAllEmploeesQuery : IRequest<IEnumerable<Employee>>
    {
    }

    public class GetAllPlayersQueryHandler : IRequestHandler<GetAllEmploeesQuery, IEnumerable<Employee>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetAllPlayersQueryHandler> _logger;

        public GetAllPlayersQueryHandler(IApplicationDbContext context, ILogger<GetAllPlayersQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Employee>> Handle(GetAllEmploeesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Employees.Include(x => x.Children).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Произошла ошибка при выводе всех записей!");
                return null;
            }
        }
    }
}