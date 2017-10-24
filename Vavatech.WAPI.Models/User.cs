using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.WAPI.Models
{
    public class User : Base
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
		
		public string Pesel { get; set; }
    }
}
