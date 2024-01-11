using Microsoft.AspNetCore.Identity;

namespace FullStackAuth_WebAPI.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SteamAccountId { get; set; }
        public string SteamId { get; set; }
    }
}
