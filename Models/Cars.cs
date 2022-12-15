using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsedCarDashboard.Models
{
    public class Cars
    {
        public int CarID { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public Decimal? Mileage { get; set; }
        public Decimal? Price { get; set; }
        public int? PreviousOwners { get; set; }
        public ICollection<Buyers> Buyers { get; set; }

    }
}
