using Employees.Models;
using Employees.Services;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Employees.Features.Child.Commands
{
    public class UpdateChildrenCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public class UpdateChildrenCommandHandler : IRequestHandler<UpdateChildrenCommand, int>
        {
            private readonly IChildrenService _childrenService;

            public UpdateChildrenCommandHandler(IChildrenService childrenService)
            {
                _childrenService = childrenService;
            }

            public async Task<int> Handle(UpdateChildrenCommand command, CancellationToken cancellationToken)
            {
                var children = await _childrenService.GetChildrenById(command.Id);
                if (children == null)
                {
                    return default;
                }
                children.Id = command.Id;
                children.LastName = command.LastName;
                children.Name = command.Name;
                children.MiddleName = command.MiddleName;
                children.BirthDate = command.BirthDate;
                children.EmployeeId = command.EmployeeId;

                return await _childrenService.UpdateChildren(children);
            }
        }
    }
}