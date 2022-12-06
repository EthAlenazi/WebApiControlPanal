using ControllPanel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllPanel.Configurations.Entities
{
    public class AccountConfigurations : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(
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
