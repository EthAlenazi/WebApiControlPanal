using ControllPanel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllPanel.Configurations.Entities
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(
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
        }
    }
}
