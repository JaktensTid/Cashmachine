using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CacheMachine.EntityFramework
{
    interface IGenericRepository<Entity> where Entity : class
    {
        Task Create(Entity item, CancellationToken cancellationToken);
        Task<Entity> FindById(Int64 Id, CancellationToken cancellationToken);
        Task<IEnumerable<Entity>> Get(CancellationToken cancellationToken);
        Task<IEnumerable<Entity>> Get(Func<Entity, bool> predicate, CancellationToken cancellationToken);
        Task Remove(Entity item, CancellationToken cancellationToken);
        Task Update(Entity item, CancellationToken cancellationToken);
    }
}
