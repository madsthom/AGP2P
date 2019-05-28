using System.Collections.Generic;
using System.Linq;
using AGP2P.Data;
using Microsoft.EntityFrameworkCore;

namespace AGP2P.Models
{
    public class TestViewModel
    {
        private ApplicationDbContext _context;
        public TestViewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        private BusinessProfile _businessProfiles;

        public List<BusinessProfile> BusinessProfiles
        {
            get { return _context.Parts.Include(bp => bp.BusinessProfile).ToList(); }
            set => throw new System.NotImplementedException();
        }

        private Part _parts;
        public List<Part> Parts { get; set; }
    }
}