using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NaughtySpirit.StoreManager.DomainObjects;

namespace NaughtySpirit.StoreManager.Utilities
{
    public class UserManager
    {
        private static readonly UserManager instance = new UserManager();

        private UserManager() { }

        public static UserManager Instance
   {
      get 
      {
         return instance; 
      }
   }

        public User User { get; set; }
    }
}
