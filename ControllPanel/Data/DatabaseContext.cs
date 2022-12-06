using ControllPanel.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllPanel.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options ): base(options) 
        { }

        

        public DbSet<Account> Accounts {  get;set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)// Seed Method is to initialize data into a database that is being created by Code First or evolved by Migrations.
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfigurations());
            builder.ApplyConfiguration(new AccountConfigurations());
            builder.ApplyConfiguration(new AddressConfigurations());
            
        }

    }

}
