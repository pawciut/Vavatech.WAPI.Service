using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.MockServices
{
    public class MockItemsService<TItem> : IBaseService<TItem>
        where TItem : Base
    {
        const string baseDir = @"C:\Temp\WebAPI_01\Projekt\Vavatech.WAPI.Service";
        readonly string filename = $@"{baseDir}\{typeof(TItem).Name}.json";
        protected IList<TItem> items;

        public MockItemsService()
        {
            Load();
        }

        void Load()
        {
            if (File.Exists(filename))
            {
                var json = File.ReadAllText(filename);
                items = JsonConvert.DeserializeObject<IList<TItem>>(json);
            }
            else
                items = new List<TItem>();
        }

        void Save()
        {
            var json = JsonConvert.SerializeObject(items);
            System.IO.File.WriteAllText(filename, json);
        }

        public void Add(TItem item)
        {
            items.Add(item);
            item.Id = items.Max(s => s.Id) + 1;
            Save();
        }

        public IList<TItem> Get()
        {
            return items;
        }

        public TItem Get(int id)
        {
            return items.SingleOrDefault(s => s.Id == id);
        }

        public void Remove(int id)
        {
            var item = Get(id);
            if (item != null)
                items.Remove(item);
            Save();
        }

        public void Update(TItem item)
        {
            var foundItem = Get(item.Id);
            if (foundItem != null)
            {
                items.Remove(foundItem);
                Add(item);
            }
        }
    }
}
