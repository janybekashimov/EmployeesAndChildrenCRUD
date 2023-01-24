using Employees.Models;
using FluentValidation;

namespace Employees.Validation
{
    public class ChildrenValidator : AbstractValidator<Children>
    {
        public ChildrenValidator()
        {
            RuleFor(x => x.LastName).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.EmployeeId).NotNull().NotEmpty();
        }
    }
}