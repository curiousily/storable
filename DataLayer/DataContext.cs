﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using NaughtySpirit.StoreManager.DomainObjects;

namespace NaughtySpirit.StoreManager.DataLayer
{
    public class StorageContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}