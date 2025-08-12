using FirstApiProj.DTO;
using FluentValidation;
using FirstApiProj.Constants;

namespace FirstApiProj.Validators
{
    public class ValidatorRegisterUser : AbstractValidator<DtoRegister>
    {
      

        public ValidatorRegisterUser()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(ValidationMessages.UserNameRequired)
                .MinimumLength(ValLengths.User.UserName.MinLength).WithMessage(ValidationMessages.UserNameLength)
                .MaximumLength(ValLengths.User.UserName.MaxLength).WithMessage(ValidationMessages.UserNameLength)
                .Matches(RegexPatterns.UserName).WithMessage(ValidationMessages.UserNameInvalid);

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidationMessages.PasswordRequired)
                .MinimumLength(ValLengths.User.Password.MinLength).WithMessage(ValidationMessages.PasswordLength)
                .MaximumLength(ValLengths.User.Password.MaxLength).WithMessage(ValidationMessages.PasswordLength)
                .Matches(RegexPatterns.Password).WithMessage(ValidationMessages.PasswordInvalid);

            RuleFor(x => x.Role)
                .Must(role => Roles.AllRoles.Contains(role))
                .WithMessage($"Role must be either ({Roles.GetRoles()})")
                .When(x => !string.IsNullOrEmpty(x.Role)); 

            RuleFor(x=>x.Email)
                .EmailAddress().WithMessage("Invalid email format")
                .When(x => !string.IsNullOrEmpty(x.Email)); 


        }
    }
}
