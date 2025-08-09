namespace FirstApiProj.Constants
{
    public static class ValidationMessages
    {
        // Validation messages for Names
        public const string NameRequired = "Name is required";
        public const string NameInvalid = "Name can only contain letters and spaces!";
        public static readonly string NameMinLength = $"Name must be at least {ValidationLengths.Name.MinLength} characters long";
        public const string NameWhitespace = "Name cannot be whitespace";        
        // Validation messages for Section
        public const string SectionRequired = "Section is required";
        public static readonly string SectionMinLength = $"Section must be at least {ValidationLengths.Section.MinLength} characters long";
        public static readonly string SectionMaxLength = $"Section must be at most {ValidationLengths.Section.MaxLength} characters long";
        public const string SectionInvalid = "Section can only contain letters and spaces!";
        // Validation messages for Address
        public const string AddressRequired = "Address is required";
        public static readonly string AddressMinLength = $"Address must be at least {ValidationLengths.Address.MinLength} characters long";
        // Validation messages for Gpa
        public static string GpaRange = $"Gpa must be between {ValidationLengths.Gpa.MinValue} and {ValidationLengths.Gpa.MaxValue}";

    }
}
