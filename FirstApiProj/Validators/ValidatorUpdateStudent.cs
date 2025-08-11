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
                .MinimumLength(ValidationLengths.Name.MinLength).WithMessage(ValidationMessages.NameMinLength)
                .When(s => !string.IsNullOrEmpty(s.Name));

            RuleFor(s => s.Section)
                .MinimumLength(ValidationLengths.Section.MinLength).WithMessage(ValidationMessages.SectionMinLength)
                .MaximumLength(ValidationLengths.Section.MaxLength).WithMessage(ValidationMessages.SectionMaxLength)
                .Matches(RegexPatterns.Section).WithMessage(ValidationMessages.SectionInvalid)
                .When(s => !string.IsNullOrEmpty(s.Section));

            RuleFor(s => s.Address)
                .MinimumLength(ValidationLengths.Address.MinLength).WithMessage(ValidationMessages.AddressMinLength)
                .When(s => !string.IsNullOrEmpty(s.Address));

            RuleFor(s => s.Gpa)
                .InclusiveBetween(ValidationLengths.Gpa.MinValue, ValidationLengths.Gpa.MaxValue)
                .WithMessage(ValidationMessages.GpaRange)
                .When(s => s.Gpa.HasValue);
        }
    }
}
