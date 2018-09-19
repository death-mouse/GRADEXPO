using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GRADEXPO.Models;
using System.Threading.Tasks;
using GRADEXPO.Repository;
using GRADEXPO.Context;
using System.Data.Entity;
using Newtonsoft.Json;

namespace GRADEXPO.Repository
{
    public class UsersRepository : IUsersRepository
    {
        public UsersRepository() { }

        public async Task<Users.User> GetUserAsync(Int32 _userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Users.User> AddUserAsync(Users.User _usersModel)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Users.User>> GetUsersAsync()
        {
            var result = new List<Users.User>();
            switch (Properties.Settings.Default.GetDataFrom)
            {
                case "Json":
                    string json = await HttpClient.Browser.GetAsync(string.Format("{0}{1}", Properties.Settings.Default.BaseUrlApi, Properties.Settings.Default.postfixGetUser));
                    Users.RootObject rootObject = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Users.RootObject>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                    result = rootObject.value;
                    break;
                    throw new System.Exception(string.Format("Приложение не умеет работать с типом данных {0}. Если вам нужно работать с такими типом данным, обратитесь к разработчику", Properties.Settings.Default.GetDataFrom));
            }
            return result;
        }

        public async Task DeleteUserAsync(Int32 id)
        {
            throw new NotImplementedException();
        }

        public async Task<Users.User> UpdateUserAsync(Users.User _usersModel)
        {
            throw new NotImplementedException();
        }
    }
}