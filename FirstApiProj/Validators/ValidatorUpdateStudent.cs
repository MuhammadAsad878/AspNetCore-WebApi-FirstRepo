using FluentValidation;
using FirstApiProj.DTO;
using FirstApiProj.Constants;

namespace FirstApiProj.Validators
{
    public class ValidatorUpdateStudent : AbstractValidator<DtoStudentUpdate>
    {
        public ValidatorUpdateStudent()
        {
            RuleFor(s => s.Name)
                .Matches(RegexPatterns.Name).WithMessage(ValidationMessages.NameRequired)
                .MinimumLength(ValLengths.Student.Name.MinLength).WithMessage(ValidationMessages.NameMinLength)
                .When(s => !string.IsNullOrEmpty(s.Name));

            RuleFor(s => s.Section)
                .MinimumLength(ValLengths.Student.Section.MinLength).WithMessage(ValidationMessages.SectionMinLength)
                .MaximumLength(ValLengths.Student.Section.MaxLength).WithMessage(ValidationMessages.SectionMaxLength)
                .Matches(RegexPatterns.Section).WithMessage(ValidationMessages.SectionInvalid)
                .When(s => !string.IsNullOrEmpty(s.Section));

            RuleFor(s => s.Address)
                .MinimumLength(ValLengths.Student.Address.MinLength).WithMessage(ValidationMessages.AddressMinLength)
                .When(s => !string.IsNullOrEmpty(s.Address));

            RuleFor(s => s.Gpa)
                .InclusiveBetween(ValLengths.Student.Gpa.MinValue, ValLengths.Student.Gpa.MaxValue)
                .WithMessage(ValidationMessages.GpaRange)
                .When(s => s.Gpa.HasValue);
        }
    }
}
