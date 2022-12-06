using AutoMapper;
using ControllPanel.Data;
using ControllPanel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllPanel.Configurations
{
    public class MapperInitilizer: Profile 
    {

        public MapperInitilizer()
        {
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Account, CreateAccountDTO>().ReverseMap();
            CreateMap<Address,AddressDTO>().ReverseMap();
            CreateMap<Address, CreateAddressDTO>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();
            CreateMap<ApiUser, LoginDTO>().ReverseMap();
        }
    }
}
