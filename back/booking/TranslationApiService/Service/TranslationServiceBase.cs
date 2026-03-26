using Globals.Abstractions;
using Globals.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using TranslationApiService.Models;

namespace Globals.Sevices
{
    public class TranslationServiceBase<T, V> : ITranslationServiceBase<T> where T : TranslationEntityBase where V : DbContext
    {
        private String TableName => $"{typeof(T).Name}s";

        protected readonly V _context;
        protected readonly ILogger<TranslationServiceBase<T, V>> _logger;

        public TranslationServiceBase(V context, ILogger<TranslationServiceBase<T, V>> logger)
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

        public virtual async Task<bool> DelEntityAsync(int EntityId)
        {
           
            var dbSet = GetDbSet(_context);
            var deleted = await dbSet
                .Where(x => x.EntityId == EntityId)
                .ExecuteDeleteAsync();

            if (deleted == 0)
            {
                _logger.LogWarning(
                    "Entities {EntityType} with id {Id} not found for deletion",
                    typeof(T).Name,
                    EntityId);

                return false;
            }
            _logger.LogInformation(
            "Entity {EntityType} with id {Id} deleted",
            typeof(T).Name,
            EntityId);

            return true;
        }

        public virtual async Task<bool> ExistsEntityAsync(int EntityId, string lang)
        {
            var query = Include();
            var exists = await query.AnyAsync(x => x.EntityId == EntityId && x.Lang == lang);

            _logger.LogInformation(
                            "Existence check for entity {EntityType} with id {Id}: {Exists}",
                            typeof(T).Name,
                            EntityId,
                            exists);
            return exists;
            
        }


        public virtual async Task<List<T>> GetEntitiesAsync(string lang)
        {
            var query = Include();
            var list = await query
                .AsNoTracking()
                    .Where(x => x.Lang == lang)
                    .ToListAsync();

            _logger.LogInformation(
                "Retrieved {Count} entities of type {EntityType}",
                list.Count,
                typeof(T).Name);

            return list;
        }


        public virtual async Task<T> GetEntityAsync(int EntityId, string lang)
        {
            var query = Include();
            var entity = await query
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.EntityId == EntityId && x.Lang == lang);

            _logger.LogInformation(
                entity != null
                    ? "Retrieved entity {EntityType} with id {Id}"
                    : "Entity {EntityType} with id {Id} not found",
                typeof(T).Name,
                EntityId);

            return entity;
        }

        public virtual async Task<bool> UpdateEntityAsync(T entity)
        {
            var dbSet = GetDbSet(_context);
                var existing = await dbSet.FirstOrDefaultAsync(x => x.EntityId == entity.EntityId && x.Lang == entity.Lang);
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

        private IQueryable<T> Include( params string[] includeProperties)
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

    public interface ITranslationServiceBase<T> where T : TranslationEntityBase
    {
        Task<Boolean> AddEntityAsync(T entity);

        Task<T> GetEntityAsync(int EntityId, string lang);

        Task<List<T>> GetEntitiesAsync(string lang);

        Task<Boolean> UpdateEntityAsync(T entity);

        Task<Boolean> DelEntityAsync(int EntityId);

        Task<bool> ExistsEntityAsync(int EntityId, string lang);
    }

   
}