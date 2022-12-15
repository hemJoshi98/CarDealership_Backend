using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsedCarDashboard.Models
{
    public class Buyers
    {
        public int BuyerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public ICollection<Cars> Cars { get; set; }
    }
}
