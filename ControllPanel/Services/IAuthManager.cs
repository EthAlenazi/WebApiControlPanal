using ControllPanel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllPanel.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginDTO userDTO);

        Task<String> CreateToken();
    }
}
