using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Mediatr.EmployeeDropDown.Queries
{
    public class GetEmployeeDropDownQuery : IRequest<IEnumerable<Employee>>
    {
    }
    public class GetEmployeeDropDownQueryHandler : IRequestHandler<GetEmployeeDropDownQuery, IEnumerable<Employee>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetEmployeeDropDownQueryHandler> _logger;

        public GetEmployeeDropDownQueryHandler(IApplicationDbContext context, ILogger<GetEmployeeDropDownQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Employee>> Handle(GetEmployeeDropDownQuery query, CancellationToken cancellationToken)
        {
            try
            {
                IEnumerable<Employee> employeeList = await _context.Employees.ToListAsync();
                return employeeList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Произошла ошибка при получении данных для DropDown!");
                return null;
            }
        }
    }
}