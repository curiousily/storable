using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaughtySpirit.StoreManager.DataLayer;
using NaughtySpirit.StoreManager.DomainObjects;

namespace NaughtySpirit.StoreManager.Utilities
{
    public class UserAuthentication
    {
        private readonly DataContext dataContext = new DataContext();

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
