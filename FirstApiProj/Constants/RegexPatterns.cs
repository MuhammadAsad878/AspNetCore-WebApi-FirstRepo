namespace FirstApiProj.Constants
{
    public static class RegexPatterns
    {
        public const string Name = @"^[A-Za-z\s]+$"; // Only letters and spaces
        public const string Section = @"^[A-Za-z\s]+$"; // Only letters and spaces
        public const string UserName = @"^[A-Za-z0-9_]+$"; // Alphanumeric and underscores
        public const string Password = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^A-Za-z0-9]).+$"; // At least one uppercase, one lowercase, one digit, and one special character

    }
}
