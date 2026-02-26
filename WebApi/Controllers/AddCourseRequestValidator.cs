using FluentValidation;

namespace WebApi.Controllers
{
    using FluentValidation;

public class AddCourseRequestValidator : AbstractValidator<AddCourseRequest>
{
    public AddCourseRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name cannot be longer than 100 characters.");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required.")
            .MaximumLength(50).WithMessage("Code cannot be longer than 50 characters.");

        RuleFor(x => x.Department)
            .NotEmpty().WithMessage("Department is required.")
            .MaximumLength(100).WithMessage("Department cannot be longer than 100 characters.");

        // RuleFor(x => x.ProfessorFirstName)
        //     .NotEmpty().WithMessage("Professor's first name is required.")
        //     .MaximumLength(100).WithMessage("Professor's first name cannot be longer than 100 characters.");

        // RuleFor(x => x.ProfessorLastName)
        //     .NotEmpty().WithMessage("Professor's last name is required.")
        //     .MaximumLength(100).WithMessage("Professor's last name cannot be longer than 100 characters.");
    }
}

    // public class NoWhiteSpaceAttribute : ValidationAttribute
    // {
    //     protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    //     {
    //         if (value is string str && string.IsNullOrWhiteSpace(str))
    //         {
    //             return new ValidationResult("The field cannot be empty or whitespace.");
    //         }
    //         return ValidationResult.Success!;
    //     }
    // }
}
