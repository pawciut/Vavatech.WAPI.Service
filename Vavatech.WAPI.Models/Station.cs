using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.WAPI.Models
{
    public class Station : Base
    {
        public Location Location { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
