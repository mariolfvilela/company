using System;
using Company.Application.ViewModels;
using DotNetCore.Validation;

namespace Company.Application.Validation
{
    public class BaseViewModelValidator<T> : Validator<T> where T : ViewModelBase
    {
        protected BaseViewModelValidator()
        {
        }
    }
}
