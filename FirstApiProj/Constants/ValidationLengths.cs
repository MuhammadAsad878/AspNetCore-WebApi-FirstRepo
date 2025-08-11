namespace FirstApiProj.Constants
{
    public static class ValidationLengths
    {

        public static class Name
        {
            public const int MinLength = 3;
            public const int MaxLength = 50; 
        }

        public static class Section
        {
            public const int MinLength = 1;
            public const int MaxLength = 2; 
        }

        public static class Address
        {
            public const int MinLength = 5;
            public const int MaxLength = 100; 
        }

        public static class Gpa
        {
            public const float MinValue = 0.00f;
            public const float MaxValue = 4.00f;
        }
    }
}
