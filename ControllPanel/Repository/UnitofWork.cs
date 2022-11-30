using ControllPanel.Data;
using ControllPanel.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllPanel.Repository
{
    public class UnitofWork : IUnitofWork
    {

        private readonly DatabaseContext _context;
        private IGenericRepository<Account> _account;
        private IGenericRepository<Address> _address;

        public UnitofWork(DatabaseContext context)
        {
            _context = context;

        }
        public IGenericRepository<Account> Account => _account ??= //if this objact is null 
            new GenericRepository<Account>(_context);// return an objact from Generic Repository type it is Account 

        public IGenericRepository<Address> Address => _address ??= new GenericRepository<Address>(_context);

        public void Dispose()
        {
            _context.Dispose();//kill all the connaction or opartions was using with an Objact 
            GC.SuppressFinalize(this);//So remove reference in finalization queue for this Objact 
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
