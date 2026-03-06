using Globals.Abstractions;
using Globals.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Globals.Sevices
{
    public class TableServiceBase<T, V> : IServiceBase<T> where T : EntityBase where V : DbContext
    {
        private String TableName => $"{typeof(T).Name}s";

        public virtual async Task<bool> AddEntityAsync(T entity)
        {
            try
            {
                using (var db = (V)Activator.CreateInstance(typeof(V)))
                {
                    var dbSet = GetDbSet(db);
                    await dbSet.AddAsync(entity);
                    await db.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex) { }
            return false;
        }

        public virtual async Task<int> AddEntityGetIdAsync(T entity)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var dbSet = GetDbSet(db);
                var res = dbSet.Add(entity);
                db.SaveChanges();
                return res.Entity.id;
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
                dbSet.Remove(existing);
                await dbSet.AddAsync(entity);

                // Attach and mark modified
                //db.Entry(entity).State = EntityState.Modified;
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




    public class TableServiceBaseNew<T, V> : IServiceBaseNew<T> where T : EntityBase where V : DbContext
    {
        private String TableName => $"{typeof(T).Name}s";
        protected readonly V _context;
        protected readonly ILogger<TableServiceBaseNew<T, V>> _logger;

        public TableServiceBaseNew(V context, ILogger<TableServiceBaseNew<T, V>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public virtual async Task<bool> AddEntityAsync(T entity)
        {
            _logger.LogInformation("Adding entity {EntityType}", typeof(T).Name);
           
            var dbSet = GetDbSet(_context);
            var res = await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Entity {EntityType} created with id {Id}",
                typeof(T).Name,
                res.Entity.id);
            return true;
        }

        public virtual async Task<int> AddEntityGetIdAsync(T entity)
        {
            _logger.LogInformation("Adding entity {EntityType}", typeof(T).Name);

            var dbSet = GetDbSet(_context);
            var res = await dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Entity {EntityType} created with id {Id}",
                typeof(T).Name,
                res.Entity.id);

            return res.Entity.id;
        }

        public virtual async Task<bool> DelEntityAsync(int id, Predicate<T>? additional = null)
        {
            var dbSet = GetDbSet(_context);
            var found = additional != null 
                ? await dbSet.FirstOrDefaultAsync(x=>x.id == id && additional.Invoke(x) == true)
                : await dbSet.FirstOrDefaultAsync(x => x.id == id);
            if (found == null)
            {
                _logger.LogWarning(
                    "Entity {EntityType} with id {Id} not found for deletion",
                    typeof(T).Name,
                    id);
                return false;
            }

            dbSet.Remove(found);
            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Entity {EntityType} with id {Id} deleted",
                typeof(T).Name,
                id);

            return true;
        }

        public virtual async Task<bool> ExistsEntityAsync(int id, Predicate<T>? additional = null)
        {
            var query = Include();
            var exists = additional != null 
                ? await query.AnyAsync(m => m.id == id && additional.Invoke(m) == true) 
                : await query.AnyAsync(m => m.id == id);

            _logger.LogInformation(
                "Existence check for entity {EntityType} with id {Id}: {Exists}",
                typeof(T).Name,
                id,
                exists);

            return exists;
        }

        public virtual async Task<List<T>> GetEntitiesAsync(Predicate<T>? additional = null, params string[] includeProperties)
        {
            var query = Include(includeProperties);
            var list = additional != null 
                ? await query.Where(x=> additional.Invoke(x) == true).ToListAsync()
                : await query.ToListAsync();

            _logger.LogInformation(
                "Retrieved {Count} entities of type {EntityType}",
                list.Count,
                typeof(T).Name);

            return list;

        }

        public virtual async Task<T> GetEntityAsync(int id, Predicate<T>? additional = null, params string[] includeProperties)
        {
            var query = Include(includeProperties);
            var entity = additional!= null 
                ? await query.FirstOrDefaultAsync(x => x.id == id && additional.Invoke(x) == true)
                : await query.FirstOrDefaultAsync(x => x.id == id);

            _logger.LogInformation(
                entity != null
                    ? "Retrieved entity {EntityType} with id {Id}"
                    : "Entity {EntityType} with id {Id} not found",
                typeof(T).Name,
                id);

            return entity;
        }

        public virtual async Task<bool> UpdateEntityAsync(T entity)
        {
            var dbSet = GetDbSet(_context);
            var existing = await dbSet.FindAsync(entity.id);
            if (existing == null)
            {
                _logger.LogWarning(
                    "Entity {EntityType} with id {Id} not found for update",
                    typeof(T).Name,
                    entity.id);
                return false;
            }

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();

            _logger.LogInformation(
                "Entity {EntityType} with id {Id} updated",
                typeof(T).Name,
                entity.id);

            return true;
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

        private IQueryable<T> Include(params string[] includeProperties)
        {
            var query = _context.Set<T>().AsQueryable();

            // Use EF model metadata to discover navigations (same approach used in ServiceBase)
            var entityType = _context.Model.FindEntityType(typeof(T));
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