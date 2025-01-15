using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Users.Commands.Validation
{
    public class EditUserValidation : AbstractValidator<EditUserCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        public EditUserValidation(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(n => n.FullName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(n => n.UserName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .EmailAddress().WithMessage(_localizer[SharedResourcesKeys.EmailValidation])
                .Length(0, 100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            //RuleFor(e => e.Password)
            //    .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            //    .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            //RuleFor(e => e.ConfirmPassword)
            //    .Equal(x => x.Password).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPassword])
            //    .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            //    .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

        }

        public void ApplyCustomValidationRules()
        {
            //RuleFor(n => n.FullName)
            //    .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameArExist(key))
            //    .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            //RuleFor(n => n.FullName)
            //    .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameEnExist(key))
            //    .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

        }
    }
}
