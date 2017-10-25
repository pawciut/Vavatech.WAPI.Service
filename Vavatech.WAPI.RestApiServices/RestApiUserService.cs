using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.RestApiServices
{
    public class GenericHttpClient
    {
        public static T Get<T>(string uri)
        {
            var address = ConfigurationManager.AppSettings["ServiceUri"];

            var client = new HttpClient();
            client.BaseAddress = new Uri(address);
            var response = client.GetAsync(uri).Result;
            var content = response.Content.ReadAsAsync<T>().Result;
            return content;
        }
    }

    public class RestApiUserService : IUsersService
    {
        readonly string address;
        public RestApiUserService()
        {
            this.address = ConfigurationManager.AppSettings["ServiceUri"];
        }

        public void Add(User item)
        {
            throw new NotImplementedException();
        }

        public IList<User> Get(UserSearchCriteria criteria)
        {
            throw new NotImplementedException();
        }

        public IList<User> Get()
        {
            var url = $"api/users";
            return GenericHttpClient.Get<IList<User>>(url);
        }

        public User Get(int id)
        {
            var url = $"api/users/{id}";
            return GenericHttpClient.Get<User>(url);
        }

        public User GetByPesel(string pesel)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
