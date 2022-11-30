using ControllPanel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllPanel.IRepository
{
    public interface IUnitofWork: IDisposable
    {
        IGenericRepository<Account> Account { get; }
        IGenericRepository<Address> Address { get; }

        Task Save(); 

    }
}
