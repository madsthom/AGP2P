using Microsoft.AspNetCore.Identity;

namespace AGP2P.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int BusinessProfileId { get; set; }
        public BusinessProfile BusinessProfile { get; set; }
    }

}