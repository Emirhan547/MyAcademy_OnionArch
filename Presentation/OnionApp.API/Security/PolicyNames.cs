namespace OnionApp.API.Security
{
    public static class PolicyNames
    {
        public const string AdminOnly = nameof(AdminOnly);
        public const string EmployeeOnly = nameof(EmployeeOnly);
        public const string MemberOrAdmin = nameof(MemberOrAdmin);
    }
}