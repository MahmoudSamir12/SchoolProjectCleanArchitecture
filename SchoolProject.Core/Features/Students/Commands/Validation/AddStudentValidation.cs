using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.IServices;

namespace SchoolProject.Core.Features.Students.Commands.Validation
{
    public class AddStudentValidation : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public AddStudentValidation(IStudentService studentService, IDepartmentService departmentService,
                                    IStringLocalizer<SharedResources> localizer)
        {
            _studentService = studentService;
            _departmentService = departmentService;
            _localizer = localizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();

        }

        public void ApplyValidationRules()
        {
            RuleFor(n => n.NameAr)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(n => n.NameEn)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(e => e.Email)
                .EmailAddress().WithMessage(_localizer[SharedResourcesKeys.EmailValidation])
                .Length(0, 100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(ad => ad.Address)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .Length(0, 100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(Ph => Ph.Phone)
                .Length(0, 15).WithMessage("Phone number must be at most 15 characters.");

            RuleFor(dob => dob.DateOfBirth)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                 .LessThan(DateTime.Now).WithMessage("Date of birth must be in the past.");

            RuleFor(student => student.DepartmentId)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);

            RuleFor(student => student.ParentId)
                .NotNull().WithMessage("Parent is required.");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(n => n.NameAr)
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameArExist(key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(n => n.NameEn)
                .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameEnExist(key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(n => n.DepartmentId)
                .MustAsync(async (key, CancellationToken) => await _departmentService.IsDepartmentExist(key))
                .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
        }

    }
}
