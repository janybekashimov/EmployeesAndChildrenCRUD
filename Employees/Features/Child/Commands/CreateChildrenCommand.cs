using Employees.Models;
using Employees.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Features.Child.Commands
{
    public class CreateChildrenCommand : IRequest<Children>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public class CreateChildrenCommandHandler : IRequestHandler<CreateChildrenCommand, Children>
        {
            private readonly IChildrenService _childrenService;

            public CreateChildrenCommandHandler(IChildrenService childrenService)
            {
                _childrenService = childrenService;
            }

            public async Task<Children> Handle(CreateChildrenCommand command, CancellationToken cancellationToken)
            {
                var children = new Children()
                {
                    Id = command.Id,
                    LastName = command.LastName,
                    Name = command.Name,
                    MiddleName = command.MiddleName,
                    BirthDate = command.BirthDate,
                    EmployeeId = command.EmployeeId,
                };
                return await _childrenService.CreateChildren(children);
            }
        }
    }
}