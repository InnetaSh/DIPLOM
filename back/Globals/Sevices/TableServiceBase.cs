using Globals.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Globals.Models;

namespace Globals.Sevices
{
    public class TableServiceBase<T, V> : IServiceBase<T> where T : EntityBase where V : DbContext
    {
        private String TableName => $"{typeof(T).Name}s";

        public virtual async Task<bool> AddEntityAsync(T entity)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var dbSet = GetDbSet(db);
                await dbSet.AddAsync(entity);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public virtual async Task<bool> DelEntityAsync(int id)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var dbSet = GetDbSet(db);
                var found = await dbSet.FindAsync(id);
                if (found == null) return false;

                dbSet.Remove(found);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public virtual async Task<bool> ExistsEntityAsync(int id)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var query = Include(db);
                return await query.AnyAsync(m => m.id == id);
            }
        }

        public virtual async Task<List<T>> GetEntitiesAsync(params string[] includeProperties)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var query = Include(db, includeProperties);
                return await query.ToListAsync();
            }
        }

        public virtual async Task<T> GetEntityAsync(int id, params string[] includeProperties)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var query = Include(db, includeProperties);
                return await query.FirstOrDefaultAsync(x => x.id == id);
            }
        }

        public virtual async Task<bool> UpdateEntityAsync(T entity)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var dbSet = GetDbSet(db);
                var existing = await dbSet.FindAsync(entity.id);
                if (existing == null) return false;

                // Attach and mark modified
                db.Entry(entity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return true;
            }
        }

        // Helpers

        private DbSet<T> GetDbSet(V db)
        {
            // 1) Try to find a DbSet property with the matching table/property name
            var props = db.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var propByName = props.FirstOrDefault(p =>
                p.Name == TableName
                && p.PropertyType.IsGenericType
                && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)
                && p.PropertyType.GetGenericArguments()[0] == typeof(T)
            );

            if (propByName != null)
            {
                var val = propByName.GetValue(db) as DbSet<T>;
                if (val != null) return val;
            }

            // 2) If not found by name, try to find any DbSet<T> property by type
            var propByType = props.FirstOrDefault(p =>
                p.PropertyType.IsGenericType
                && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>)
                && p.PropertyType.GetGenericArguments()[0] == typeof(T)
            );

            if (propByType != null)
            {
                var val = propByType.GetValue(db) as DbSet<T>;
                if (val != null) return val;
            }

            // 3) Fallback to the DbContext.Set<T>()
            return db.Set<T>();
        }

        private IQueryable<T> Include(V db, params string[] includeProperties)
        {
            var query = db.Set<T>().AsQueryable();

            // Use EF model metadata to discover navigations (same approach used in ServiceBase)
            var entityType = db.Model.FindEntityType(typeof(T));
            if (entityType == null) return query;

            var navigations = entityType.GetDerivedTypesInclusive()
                                        .SelectMany(type => type.GetNavigations())
                                        .Distinct();

            foreach (var property in navigations)
            {
                if (includeProperties.Length > 0 && !includeProperties.Contains(property.Name)) continue;
                query = query.Include(property.Name);
            }

            return query;
        }
    }
}