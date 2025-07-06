namespace api.Models
{
    public static class UserRole
    {
        public const string Admin = "Admin";

        public const string User = "User";

        public static readonly string[] All = [Admin, User];
    }
}