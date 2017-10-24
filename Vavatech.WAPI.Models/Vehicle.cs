using System;

namespace Vavatech.WAPI.Models
{
    public class Vehicle : Base
    {
        public DateTime ProductionDate { get; set; }

        public string Number { get; set; }

        public bool IsDeleted { get; set; }
    }
}
