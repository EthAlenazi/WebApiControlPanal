using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControllPanel.IRepository
{
    public interface IGenericRepository<T> where T : class //Created as general Declaration 
    {
        //Task<TResult> method that's for an async method
        //Also returns a value.

        //Get List of objacts
        //when I putfuncation = null make this parameters as optional 
        Task<IList<T>> GetAll(
            Expression<Func<T, bool>> exception = null,
            Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null
            );

        //Get one objact
        Task<T> Get(Expression<Func<T, bool>> exception, List<string> includes = null);

        //Task without<> for an async method that performs
        //an operation but returns no value
        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> entities);
        Task Delete(int id);


       //void method for event handler
        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);


    }
}
