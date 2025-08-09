using FirstApiProj.DTO;
using FluentValidation;
using FirstApiProj.Constants;
namespace FirstApiProj.Validators
{
    public class ValidatorCreateStudent : AbstractValidator<DtoCreateStudent>
    {
        // Validator for creating a new student
        public ValidatorCreateStudent()
        {

            RuleFor(s => s.Name)
                .NotEmpty().WithMessage(ValidationMessages.NameRequired)
                .Matches(RegexPatterns.Name).WithMessage(ValidationMessages.NameInvalid)
                .MinimumLength(ValidationLengths.Name.MinLength).WithMessage(ValidationMessages.NameMinLength)
                .Must(name => !string.IsNullOrWhiteSpace(name)).WithMessage(ValidationMessages.NameWhitespace);


            RuleFor(s => s.Section)
                .NotEmpty().WithMessage(ValidationMessages.SectionRequired)
                .MinimumLength(ValidationLengths.Section.MinLength).WithMessage(ValidationMessages.SectionMinLength)
                .MaximumLength(ValidationLengths.Section.MaxLength).WithMessage(ValidationMessages.SectionMaxLength)
                .Matches(RegexPatterns.Section).WithMessage(ValidationMessages.SectionInvalid);

            RuleFor(s => s.Address)
                .NotEmpty().WithMessage(ValidationMessages.AddressRequired)
                .MinimumLength(ValidationLengths.Address.MinLength).WithMessage(ValidationMessages.AddressMinLength);


            RuleFor(s => s.Gpa)
                .InclusiveBetween(ValidationLengths.Gpa.MinValue,ValidationLengths.Gpa.MaxValue).WithMessage(ValidationMessages.GpaRange);
        }

        

    }
}
