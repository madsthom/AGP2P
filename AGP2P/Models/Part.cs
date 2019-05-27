using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGP2P.Models
{
    public class Part
    {
        public int PartId { get; set; }
        public string PartName { get; set; }
        public int Amount { get; set; }



        public int BusinessProfileId { get; set; }
        public BusinessProfile BusinessProfile { get; set; }

    }
}