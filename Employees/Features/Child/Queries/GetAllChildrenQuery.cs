using Employees.Models;
using Employees.Services;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Features.Child.Queries
{
    public class GetAllChildrenQuery : IRequest<IEnumerable<Children>>
    {
        public class GetAllChildrenQueryHandler : IRequestHandler<GetAllChildrenQuery, IEnumerable<Children>>
        {
            private readonly IChildrenService _childrenService;

            public GetAllChildrenQueryHandler(IChildrenService childrenService)
            {
                _childrenService = childrenService;
            }

            public async Task<IEnumerable<Children>> Handle(GetAllChildrenQuery query, CancellationToken cancellationToken)
            {
                return await _childrenService.GetChildrenList();
            }
        }
    }
}