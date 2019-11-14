using System;
using Company.Application.ViewModels;
using DotNetCore.Validation;
using FluentValidation;

namespace Company.Application.Validation
{
    public sealed class CustomerViewModelValidator : BaseViewModelValidator<CustomerViewModel>
    {
        public CustomerViewModelValidator()
        {
            RuleFor(x => x.BirthDate).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
        }
    }
}
