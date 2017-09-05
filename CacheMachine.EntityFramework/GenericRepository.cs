using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CacheMachine.EntityFramework
{
    class GenericRepository<Entity> : IDisposable, IGenericRepository<Entity> where Entity : class
    {
        public DbSet<Entity> Set { get; }
        public DbContext Context { get; }

        public GenericRepository(DbContext context)
        {
            Context = context;
            Set = context.Set<Entity>();
        }

        public Task Create(Entity item, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                Set.AddOrUpdate(item);
            }, cancellationToken);
        }

        public Task<Entity> FindById(Int64 Id, CancellationToken cancellationToken)
        {
            return Set.FindAsync(cancellationToken, Id);
        }

        public Task<IEnumerable<Entity>> Get(CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew<IEnumerable<Entity>>(() => 
            Set.AsNoTracking().ToList(), cancellationToken);
        }

        public Task<IEnumerable<Entity>> Get(Func<Entity, bool> predicate, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => 
            Set.AsNoTracking().Where(predicate), cancellationToken);
        }

        public Task Remove(Entity item, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                Set.Remove(item);
            }, cancellationToken);
        }

        public Task Update(Entity item, CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() =>
            {
                Set.AddOrUpdate(item);
            }, cancellationToken);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
