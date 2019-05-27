using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGP2P.Models
{
    public class BusinessProfile
    {
        public int BusinessProfileId { get; set; }
        public string BusinessName { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


        public ICollection<Part> Parts { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}