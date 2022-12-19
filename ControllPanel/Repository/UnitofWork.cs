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

        #region explain how to this Class works.. 
        //        return an instance of the reposotory but then we have to
        //        backtrace a bit so i need two privet method 

        //        if the private proparty is empaty then return a new instance of
        //        Generic repository 

        //        if it's null then return an object of the
        //        Generic repository of type X(where X is table name)
        //        this like a register note this just like rolodex
        //        to say that all of these are poyential Generic repository
        //        once you are in the uint of work i have access to
        //        theevery tables that you defind you need to make sure that you
        //        make repeseniation for it in the

        #endregion
        public IGenericRepository<Account> Account => _account ??= new GenericRepository<Account>(_context);
        //if this objact is null return an objact type is Generic Repository 
        //if the private property is empty then return a new instance of Generic Repository 
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
