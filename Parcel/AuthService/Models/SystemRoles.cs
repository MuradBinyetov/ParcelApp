namespace AuthService.Models
{
    public sealed class SystemRoles
    {
        public const string AdminRole = "Admin";
        public const string UserRole = "User";
        public const string CourierRole = "Courier";

        public static readonly IList<string> AllRoles = new List<string>
        {
            AdminRole,
            UserRole,
            CourierRole,
        };
    }
}
