using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.MockServices
{
    public class MockVehiclesService : MockItemsService<Vehicle>, IVehiclesService
    {
        public MockVehiclesService()
		: base()
        {
        }
    }
}
