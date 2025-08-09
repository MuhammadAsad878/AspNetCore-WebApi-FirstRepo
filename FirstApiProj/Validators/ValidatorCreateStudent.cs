using FirstApiProj.DTO;
using FluentValidation;
using FirstApiProj.Constants;
namespace FirstApiProj.Validators
{
    public class ValidatorCreateStudent : AbstractValidator<DtoCreateStudent>
    {        
        public ValidatorCreateStudent()
        {

            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Name is required")
                .Matches(Regex.Name).WithMessage("Name can only contain letters and spaces!")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters long")
                .Must(name => !string.IsNullOrWhiteSpace(name)).WithMessage("Name cannot be whitespace");


            RuleFor(s => s.Section)
                .NotEmpty().WithMessage("Section is required")
                .MinimumLength(2).WithMessage("Section must be at least 2 characters long")
                .MaximumLength(10).WithMessage("Section must be at most 10 characters long")
                .Matches(@"^[A-Za-z\s]+$").WithMessage("Section can only contain letters and spaces!");

            RuleFor(s => s.Address)
                .NotEmpty().WithMessage("Address is required")
                .MinimumLength(5).WithMessage("Address must be at least 5 characters long");


            RuleFor(s => s.Gpa)
                .InclusiveBetween(0.00f, 4.00f).WithMessage("Gpa must be between 0.00 and 4.00");
        }

        

    }
}
