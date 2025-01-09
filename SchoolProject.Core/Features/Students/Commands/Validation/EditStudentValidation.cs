using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.IServices;

namespace SchoolProject.Core.Features.Students.Commands.Validation
{
    public class EditStudentValidation : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;
        public EditStudentValidation(IStudentService studentService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            _studentService = studentService;
        }

        public void ApplyValidationRules()
        {
            RuleFor(n => n.NameAr)
                .NotEmpty().WithMessage("Name is required")
                .NotNull().WithMessage("Name Must Not Be Null")
                .Length(1, 100)
                .WithMessage("Name must be between 1 and 100 characters.");

            RuleFor(n => n.NameEn)
                .NotEmpty().WithMessage("Name is required")
                .NotNull().WithMessage("Name Must Not Be Null")
                .Length(1, 100)
                .WithMessage("Name must be between 1 and 100 characters.");

            RuleFor(e => e.Email)
                .EmailAddress()
                .WithMessage("A valid email address is required.")
                .Length(0, 200)
                .WithMessage("Email must be at most 200 characters.");

            RuleFor(ad => ad.Address)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyValue} Must Not Be Null")
                .Length(0, 500)
                .WithMessage("Address must be at most 500 characters.");

            RuleFor(Ph => Ph.Phone)
                .Length(0, 15)
                .WithMessage("Phone number must be at most 15 characters.");

            RuleFor(dob => dob.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth is required.")
                .LessThan(DateTime.Now)
                .WithMessage("Date of birth must be in the past.");

            RuleFor(student => student.DepartmentId)
                .NotNull()
                .WithMessage("Department is required.");

            RuleFor(student => student.ParentId)
                .NotNull()
                .WithMessage("Parent is required.");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(n => n.NameAr)
                .MustAsync(async (model, key, CancellationToken)
                                    => !await _studentService.IsNameArExistExcludeSelf(key, model.Id))
                .WithMessage("Name Is Exist");

            RuleFor(n => n.NameEn)
                .MustAsync(async (model, key, CancellationToken)
                                    => !await _studentService.IsNameEnExistExcludeSelf(key, model.Id))
                .WithMessage("Name Is Exist");
        }
    }
}
