namespace FirstApiProj.Constants
{
    public static class ValidationMessages
    {
        // Validation messages for Names
        public const string NameRequired = "Name is required";
        public const string NameInvalid = "Name can only contain letters and spaces!";
        public static readonly string NameMinLength = $"Name must be at least {ValLengths.Student.Name.MinLength} characters long";
        public const string NameWhitespace = "Name cannot be whitespace";        
        public const string SectionRequired = "Section is required";
        public static readonly string SectionMinLength = $"Section must be at least {ValLengths.Student.Section.MinLength} characters long";
        public static readonly string SectionMaxLength = $"Section must be at most {ValLengths.Student.Section.MaxLength} characters long";
        public const string SectionInvalid = "Section can only contain letters and spaces!";
        public const string AddressRequired = "Address is required";
        public static readonly string AddressMinLength = $"Address must be at least {ValLengths.Student.Address.MinLength} characters long";
        public static string GpaRange = $"Gpa must be between {ValLengths.Student.Gpa.MinValue} and {ValLengths.Student.Gpa.MaxValue}";

        // validation messages for User
        public const string UserNameRequired = "Username Required !";
        public static readonly string UserNameLength = $"Username must be between {ValLengths.User.UserName.MinLength} and {ValLengths.User.UserName.MaxLength} characters long.";
        public const string UserNameInvalid = "Username can only contain alphanumeric characters and underscores!";
        public const string PasswordRequired = "Password Not be Empty" ;
        public static readonly string PasswordLength = $"Password must be between {ValLengths.User.Password.MinLength} and {ValLengths.User.Password.MaxLength} characters long.";
        public const string PasswordInvalid = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.";

    }
}
