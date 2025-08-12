namespace FirstApiProj.Constants
{
    public class Roles
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public static readonly string[] AllRoles = { Admin, User };

        public static string GetRoles()
        {
            return string.Join(", ", AllRoles);

        }
    }
}
