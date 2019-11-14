using System;
using Company.Application.ViewModels;
using DotNetCore.Validation;
using FluentValidation;

namespace Company.Application.Validation
{
    public sealed class UserViewModelValidator : BaseViewModelValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Roles).NotEmpty();
        }
    }
}
