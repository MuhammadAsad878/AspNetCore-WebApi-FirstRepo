namespace FirstApiProj.DTO
{
    public class DtoRegister
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "User"; // Default role is "User"
    }
}
