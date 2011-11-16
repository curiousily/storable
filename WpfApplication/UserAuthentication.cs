using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaughtySpirit.StoreManager.DataLayer;
using NaughtySpirit.StoreManager.DomainObjects;

namespace WpfApplication
{
    public class UserAuthentication
    {
        private readonly StorageContext dataContext = new StorageContext();

        public User Authenticate(String username, String password)
        {
            var users = from user in dataContext.Users where user.Name == username && user.Password == password select user;
            if (users.Count<User>() == 0)
            {
                return null;
            }
            IEnumerable<User> userCollection = users;
            return userCollection.ElementAt<User>(0);
        }
    }
}
