namespace FirstApiProj.Constants
{
    public static class ValidationMessages
    {
        public const string NameRequired = "Name is required";
        public const string NameInvalid = "Name can only contain letters and spaces!";
        public const string NameMinLength = "Name must be at least 3 characters long";
        public const string NameWhitespace = "Name cannot be whitespace";
        public const string SectionRequired = "Section is required";
        public const string SectionMinLength = "Section must be at least 2 characters long";
        public const string SectionMaxLength = "Section must be at most 10 characters long";
        public const string SectionInvalid = "Section can only contain letters and spaces!";
        public const string AddressRequired = "Address is required";
        public const string AddressMinLength = "Address must be at least 5 characters long";
        public const string GpaRange = "Gpa must be between 0.00 and 4.00";

    }
}
