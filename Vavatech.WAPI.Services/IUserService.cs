using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.Services
{
    public interface IUsersService: IBaseService<User>
	{
        User GetByPesel(string pesel);
	}
}
