using Globals.Abstractions;
using Globals.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using TranslationApiService.Models;

namespace Globals.Sevices
{
    public class TranslationServiceBase<T, V> : ITranslationServiceBase<T> where T : TranslationEntityBase where V : DbContext, new()
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

        public virtual async Task<bool> DelEntityAsync(int EntityId, string lang)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            //using (var db = new V())
            {
                var dbSet = GetDbSet(db);
                var found =  dbSet.FirstOrDefault( x => x.EntityId == EntityId && x.Lang == lang);
                if (found == null) return false;

                dbSet.Remove(found);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public virtual async Task<bool> ExistsEntityAsync(int EntityId, string lang)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var query = Include(db);
                return await query.AnyAsync(x => x.EntityId == EntityId && x.Lang == lang);
            }
        }


        public virtual async Task<List<T>> GetEntitiesAsync(string lang)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var query = Include(db);
                return await query
                    .Where(x => x.Lang == lang)
                    .ToListAsync();
            }
        }


        public virtual async Task<T> GetEntityAsync(int EntityId, string lang)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var query = Include(db);
                return await query.FirstOrDefaultAsync(x => x.EntityId == EntityId && x.Lang == lang);
            }
        }

        public virtual async Task<bool> UpdateEntityAsync(T entity)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var dbSet = GetDbSet(db);
                var existing = await dbSet.FirstOrDefaultAsync(x => x.EntityId == entity.EntityId && x.Lang == entity.Lang);
                if (existing == null) return false;
                dbSet.Remove(existing);
                await dbSet.AddAsync(entity);

              
                await db.SaveChangesAsync();
                return true;
            }
        }



        private DbSet<T> GetDbSet(V db)
        {
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

    public interface ITranslationServiceBase<T> where T : TranslationEntityBase
    {
        Task<Boolean> AddEntityAsync(T entity);

        Task<T> GetEntityAsync(int EntityId, string lang);

        Task<List<T>> GetEntitiesAsync(string lang);

        Task<Boolean> UpdateEntityAsync(T entity);

        Task<Boolean> DelEntityAsync(int EntityId, string lang);

        Task<bool> ExistsEntityAsync(int EntityId, string lang);
    }

   
}