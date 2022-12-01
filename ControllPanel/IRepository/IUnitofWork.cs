using ControllPanel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllPanel.IRepository
{
    public interface IUnitofWork: IDisposable
    {
        //going to act like a register for every variation of the generic repository relative to the class T
        IGenericRepository<Account> Account { get; }
        IGenericRepository<Address> Address { get; }

        Task Save(); 

    }
}
