using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.MockServices
{
    public class MockUsersService : MockItemsService<User>, IUsersService
    {
        public MockUsersService()
		: base()
        {
        }
		
        public User GetByPesel(string pesel)
		{
			if(string.IsNullOrEmpty(pesel))
				throw new ArgumentNullException(nameof(pesel));
			if(pesel.Length != 11)
				throw new ArgumentException(nameof(pesel));
			
			//..
			
			return items.SingleOrDefault(u=>u.Pesel == pesel);
		}
    }
}
