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

        protected override void OnModelCreating(ModelBuilder builder)// Seed Method is to initialize data into a database that is being created by Code First or evolved by Migrations.
        {

            builder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    Street = "Olaya Street",
                    City = "Riyadh",
                    Country = "Saudi Arabia",
                    ZipCode = 11461
                },
                new Address
                {
                    Id = 2,
                    Street = "king abdulaziz road",
                    City = "Khubar",
                    Country = "Saudi Arabia",
                    ZipCode = 31952
                },
                new Address
                {
                    Id = 3,
                    Street = "Juffali Building, Madinah Road",
                    City = "Jeddah",
                    Country = "Saudi Arabia",
                    ZipCode = 21442
                }
                );

            builder.Entity<Account>().HasData(
               new Account
               {
                   Id = 1,
                   PersonalId = 12345674321,
                   FirstName = "Ahmad",
                   LastName = "Saeed",
                   Email = "Alotio123@gmail.com",
                   MobileNumber = 966565433332,
                   IsFemale = false,
                   IsAdmin = true,
                   IsActive = true,
                   ProfilePhotopath = "C:\\Users\\Atheer Alonizi\\Pictures\\Photos\\User_1.PNG",
                   AddressId = 1
               },
               new Account
               {
                   Id = 2,
                   PersonalId = 12343215432,
                   FirstName = "Sahar",
                   LastName = "Mohammed",
                   Email = "Sa7ar@gmail.com",
                   MobileNumber = 966545321888,
                   IsFemale = true,
                   IsAdmin = false,
                   IsActive = true,
                   ProfilePhotopath = "C:\\Users\\Atheer Alonizi\\Pictures\\Photos\\User_2.PNG",
                   AddressId = 2
               },
               new Account
               {
                   Id = 3,
                   PersonalId = 1221376459,
                   FirstName = "Fahad",
                   LastName = "Saleh",
                   Email = "Saleh11@gmail.com",
                   MobileNumber = 966535432221,
                   IsFemale = true,
                   IsAdmin = true,
                   IsActive = true,
                   ProfilePhotopath = "C:\\Users\\Atheer Alonizi\\Pictures\\Photos\\User_3.PNG",
                   AddressId = 3
               }
               );
        }

    }

}
