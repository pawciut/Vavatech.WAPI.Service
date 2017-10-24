using System;
using System.Collections.Generic;
using System.Text;

namespace Vavatech.WAPI.Services
{
    public interface IBaseService<TItem>
    {
        IList<TItem> Get();

        TItem Get(int id);

        void Add(TItem item);

        void Update(TItem item);

        void Remove(int id);
    }
}
