using ControllPanel.Data;
using ControllPanel.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControllPanel.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //private because we don't need do any modification in this file
        private readonly DatabaseContext _context;

        #region
       // Why do we use 2 objects here _context also _db?

       //actually when we use _context object it must use one table but _db allow us to access all tables in our context
        #endregion
        private readonly DbSet<T> _db;

        public GenericRepository(DatabaseContext context)
        {
            _context = context; 
            _db = _context.Set<T>();//assign value to T , this value should be inside the context

        }
        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
          
            _db.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> exception, List<string> includes =null)
        {
            IQueryable<T> query = _db;
            if (includes!= null)
            {
                foreach(var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(exception);
            //Using AsNoTracking with read-only(Get/select..) senior makes the method less overhead for CPU
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> exception = null, 
            Func<IQueryable<T>,
                IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null)
        {
            IQueryable<T> query = _db;
            if(exception != null)
            {
                query = query.Where(exception);

            }

            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {

                query = orderBy(query);
            }
            return await query.AsNoTracking().ToListAsync();
            //Using AsNoTracking with read-only(Get/select..) senior makes the method less overhead for CPU

        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _db.Attach(entity);//Begins tracking the given entity and entries reachable from the given entity using the Unchanged(add,delete...) state
            _context.Entry(entity).State = EntityState.Modified;//if the object has updated value change entity status to modified.

        }
    }
}
