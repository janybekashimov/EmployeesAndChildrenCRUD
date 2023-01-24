using Employees.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Features.Child.Commands
{
    public class DeleteChildrenCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteChildrenCommandHandler : IRequestHandler<DeleteChildrenCommand, int>
        {
            private readonly IChildrenService _childrenService;

            public DeleteChildrenCommandHandler(IChildrenService childrenService)
            {
                _childrenService = childrenService;
            }

            public async Task<int> Handle(DeleteChildrenCommand command, CancellationToken cancellationToken)
            {
                var children = await _childrenService.GetChildrenById(command.Id);
                if (children == null)
                {
                    return default;
                }
                return await _childrenService.DeleteChildren(children);
            }
        }
    }
}