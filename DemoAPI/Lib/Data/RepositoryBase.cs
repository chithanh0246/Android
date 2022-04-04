using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Data
{
    public abstract class RepositoryBase<T> where T: class
    {
        protected ApplicationDbContext dataContext;
        protected readonly IDbSet<T> dbset;

        protected RepositoryBase(DbContextFactory factory)
        {
            dataContext = factory.DataContext;
            dbset = dataContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
        }   

        public virtual T GetById(object id)
        {
            return dbset.Find(id);
        }
        
        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

    }
}
