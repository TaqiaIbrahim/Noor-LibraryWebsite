using Microsoft.AspNetCore.Identity;

namespace Noor_Library.Models
{
    public class ApplicationUser:IdentityUser
    {

        public string firstName { get; set; }
        public string lastName { get; set; }
        public byte[]? profile { get; set; }
    }
}
