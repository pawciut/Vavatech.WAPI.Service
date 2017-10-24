using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Vavatech.WAPI.MockServices;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.MockServices
{	
    public class MockStationsService : MockItemsService<Station>, IStationsService
    {
        public MockStationsService()
		: base()
        {
			//filename = @"C:\Temp\WebAPI_01\Projekt\Vavatech.WAPI.Service\database.json";
        }
		
        public Station Get(string name)
        {
            return items.SingleOrDefault(s => s.Name == name);
        }
    }
}
