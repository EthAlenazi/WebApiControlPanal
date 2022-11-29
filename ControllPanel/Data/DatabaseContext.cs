using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllPanel.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options ): base(options) 
        { }

        public DbSet<Account> Accounts {  get;set; }
        public DbSet<Address> Addresses { get; set; }

    }

}
