﻿using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validation
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