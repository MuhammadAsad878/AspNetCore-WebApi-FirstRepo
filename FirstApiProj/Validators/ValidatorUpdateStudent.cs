using FluentValidation;
using FirstApiProj.DTO;

namespace FirstApiProj.Validators
{
    public class ValidatorUpdateStudent : AbstractValidator<DtoStudentUpdate>
    {
        public ValidatorUpdateStudent()
        {
            RuleFor(s => s.Name)
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Name can only contain letters and spaces!")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters long")
                .When(s => !string.IsNullOrEmpty(s.Name));

            RuleFor(s => s.Section)
                .MinimumLength(2).WithMessage("Section must be at least 2 characters long")
                .MaximumLength(10).WithMessage("Section must be at most 10 characters long")
                .Matches(@"^[A-Za-z\s]+$").WithMessage("Section can only contain letters and spaces!")
                .When(s => !string.IsNullOrEmpty(s.Section));

            RuleFor(s => s.Address)
                .MinimumLength(5).WithMessage("Address must be at least 5 characters long")
                .When(s => !string.IsNullOrEmpty(s.Address));

            RuleFor(s => s.Gpa)
                .InclusiveBetween(0.00f, 4.00f).WithMessage("Gpa must be between 0.00 and 4.00")
                .When(s => s.Gpa.HasValue);
        }
    }
}
