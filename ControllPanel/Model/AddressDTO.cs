using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllPanel.Model
{


        public class CreateAddressDTO
        {

            public string Country { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public int ZipCode { get; set; }
        }  
        public class AddressDTO :CreateAddressDTO
        {

            public int Id { get; set; }
        public virtual IList<AccountDTO> AccountDTO { get; set; }

    }
    }
}
