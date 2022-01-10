using Microsoft.EntityFrameworkCore;
using QuickTemplate.Logic.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTemplate.Logic.Controllers
{
    public abstract partial class GenericController<E> : ControllerObject
        where E : Entities.IdentityObject
    {
        protected GenericController() 
            : base(new ProjectDbContext())
        {
        }
        protected GenericController(ControllerObject other)
            : base(other)
        {
        }

        public virtual DbSet<E> Set => Context.GetDbSet<E>();

        public virtual async Task<E> GetByIdAsync(int id)
        {
            return await Set.FindAsync(id).ConfigureAwait(false);
        }

        public virtual async Task<E> InsertAsync(E entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await Set.AddAsync(entity).ConfigureAwait(false);
            return entity;
        }
        public virtual async Task<IEnumerable<E>> InsertAsync(IEnumerable<E> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            await Set.AddRangeAsync(entities).ConfigureAwait(false);
            return entities;
        }
        public virtual Task UpdateAsync(E entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            return Task.Run(() => Set.Update(entity));
        }
        public virtual Task UpdateAsync(IEnumerable<E> entities)
        {
            if (entities is null)
            {
                throw new ArgumentNullException(nameof(entities));
            }
            return Task.Run(() => Set.UpdateRange(entities));
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id).ConfigureAwait(false);

            Set.Remove(entity);
        }

        public virtual Task DeleteAsync(E entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            return Task.Run(() => Set.Remove(entity));
        }

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}
