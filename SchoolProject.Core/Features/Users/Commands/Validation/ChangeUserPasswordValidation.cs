using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Users.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Features.Users.Commands.Validation
{
    public class ChangeUserPasswordValidation : AbstractValidator<ChangeUserPasswordCommand>
    {
        private readonly IStringLocalizer<SharedResources> _localizer;
        public ChangeUserPasswordValidation(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(n => n.Id)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(n => n.CurrentPassword)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(n => n.NewPassword)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(e => e.ConfirmPassword)
                .Equal(x => x.NewPassword).WithMessage(_localizer[SharedResourcesKeys.PasswordNotEqualConfirmPassword])
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

        }

        public void ApplyCustomValidationRules()
        {

        }
    }
}
