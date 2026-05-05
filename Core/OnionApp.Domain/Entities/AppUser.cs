using Microsoft.AspNetCore.Identity;

namespace OnionApp.Domain.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
    }
}