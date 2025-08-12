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
                .MinimumLength(ValLengths.Student.Name.MinLength).WithMessage(ValidationMessages.NameMinLength)
                .Must(name => !string.IsNullOrWhiteSpace(name)).WithMessage(ValidationMessages.NameWhitespace);


            RuleFor(s => s.Section)
                .NotEmpty().WithMessage(ValidationMessages.SectionRequired)
                .MinimumLength(ValLengths.Student.Section.MinLength).WithMessage(ValidationMessages.SectionMinLength)
                .MaximumLength(ValLengths.Student.Section.MaxLength).WithMessage(ValidationMessages.SectionMaxLength)
                .Matches(RegexPatterns.Section).WithMessage(ValidationMessages.SectionInvalid);

            RuleFor(s => s.Address)
                .NotEmpty().WithMessage(ValidationMessages.AddressRequired)
                .MinimumLength(ValLengths.Student.Address.MinLength).WithMessage(ValidationMessages.AddressMinLength);


            RuleFor(s => s.Gpa)
                .InclusiveBetween(ValLengths.Student.Gpa.MinValue,ValLengths.Student.Gpa.MaxValue).WithMessage(ValidationMessages.GpaRange);
        }

        

    }
}
