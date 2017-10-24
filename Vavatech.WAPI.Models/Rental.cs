using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.WAPI.Models
{
    public class Rental : Base
    {
        public DateTime StartDate { get; set; }

        public Station StartStation { get; set; }

        public DateTime? EndDate { get; set; }

        public Station EndStation { get; set; }

        public User Rentee { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
