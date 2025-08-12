namespace FirstApiProj.Model
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
