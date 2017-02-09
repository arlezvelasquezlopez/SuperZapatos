using SuperZapatos.InventoryContro.Library.InfrastructureContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SuperZapatos.InvetoryControl.Infrastructure.Context;
using System.Data.Entity;

namespace SuperZapatos.InvetoryControl.Infrastructure.Repositories
{
    public class Repository<TObject> : IRepository<TObject> where TObject : class
    {
        protected InventoryControlContext Context = null;
        private bool shareContext = false;

        public Repository()
        {
            Context = new InventoryControlContext();
        }

        public Repository(InventoryControlContext context)
        {
            Context = context;
            shareContext = true;
        }

        protected DbSet<TObject> DbSet
        {
            get
            {
                return Context.Set<TObject>();
            }
        }

        public void Dispose()
        {
            if (shareContext && (Context != null))
                Context.Dispose();
        }


        public bool Contains(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        public TObject Create(TObject t)
        {

            var newEntry = DbSet.Add(t);
            if (!shareContext)
                Context.SaveChanges();
            return newEntry;
        }      

        public int Delete(TObject t)
        {          
            DbSet.Remove(t);
            if (!shareContext)
                return Context.SaveChanges();
            return 0;
        }

        public IQueryable<TObject> Filter(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable<TObject>();
        }

        public TObject Find(Expression<Func<TObject, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public TObject Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public IQueryable<TObject> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public int Update(TObject t)
        {
            var entry = Context.Entry(t);
            DbSet.Attach(t);
            entry.State = EntityState.Modified;
            if (!shareContext)
                return Context.SaveChanges();
            return 0;
        }
    }
}
