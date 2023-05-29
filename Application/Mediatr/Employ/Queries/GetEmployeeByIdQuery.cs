using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.Employ.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }
    }
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<IApplicationDbContext> _logger;

        public GetEmployeeByIdQueryHandler(IApplicationDbContext context, ILogger<IApplicationDbContext> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Employees.Include(x => x.Children).FirstOrDefaultAsync(x => x.Id == query.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Прозошла ошибка при выводе записи по Id");
                return null;
            }
        }
    }
    
}