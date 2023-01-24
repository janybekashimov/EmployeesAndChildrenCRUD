using Employees.Models;
using Employees.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Features.Child.Queries
{
    public class GetChildrenByIdQuery : IRequest<Children>
    {
        public int Id { get; set; }

        public class GetChildrenByIdQueryHandler : IRequestHandler<GetChildrenByIdQuery, Children>
        {
            private readonly IChildrenService _childrenService;

            public GetChildrenByIdQueryHandler(IChildrenService childrenService)
            {
                _childrenService = childrenService;
            }

            public async Task<Children> Handle(GetChildrenByIdQuery query, CancellationToken cancellationToken)
            {
                return await _childrenService.GetChildrenById(query.Id);
            }
        }
    }
}