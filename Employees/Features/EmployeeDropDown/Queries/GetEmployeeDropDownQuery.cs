using Employees.Models;
using Employees.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Features.EmployeeDropDown.Queries
{
    public class GetEmployeeDropDownQuery : IRequest<IEnumerable<Employee>>
    {
        public class GetEmployeeDropDownQueryHandler : IRequestHandler<GetEmployeeDropDownQuery, IEnumerable<Employee>>
        {
            private readonly IDropDownSelectService _dropDownSelectService;

            public GetEmployeeDropDownQueryHandler(IDropDownSelectService dropDownSelectService)
            {
                _dropDownSelectService = dropDownSelectService;
            }

            public Task<IEnumerable<Employee>> Handle(GetEmployeeDropDownQuery query, CancellationToken cancellationToken)
            {
                return _dropDownSelectService.GetDropDownEmployeesList();
            }
        }
    }
}