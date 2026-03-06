using Globals.Abstractions;
using Globals.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals.Sevices
{
    public class ServiceBase<T, V> : IServiceBase<T> where T : EntityBase where V : ContextBase<T>
    {
        //public virtual async Task<bool> AddEntityAsync(T entity)
        //{
        //    var result = false;
        //    using (var db = (V)Activator.CreateInstance(typeof(V)))
        //    {
        //        db.Values.Add(entity);
        //        db.SaveChanges();
        //        result = true;
        //    }
        //    return result;
        //}

        public virtual async Task<int> AddEntityGetIdAsync(T entity)
        {            
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var res = db.Values.Add(entity);
                db.SaveChanges();
                return res.Entity.id;
            }
        }

        public virtual async Task<bool> DelEntityAsync(int id)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var findEntity = db.Values.FirstOrDefault(x => x.id == id);
                if (findEntity == null) return false;

                db.Values.Remove(findEntity);
                db.SaveChanges();
            }
            return true;
        }

        public async Task<bool> ExistsEntityAsync(int id)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                return await db.Values.AnyAsync(m => m.id == id);
            }
        }

        public virtual async Task<List<T>> GetEntitiesAsync(params string[] includeProperties)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var query = Include(db, includeProperties);
                return query?.ToList();
            }
        }

        public virtual async Task<T> GetEntityAsync(int id, params string[] includeProperties)
        {
            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var query = Include(db, includeProperties);
                return query?.FirstOrDefault(x => x.id == id);
            }
        }

        public virtual async Task<bool> UpdateEntityAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            using (var db = (V)Activator.CreateInstance(typeof(V)))
            {
                var existingEntity = await db.Values.FindAsync(entity.id);
                if (existingEntity == null)
                    return false;

                db.Entry(existingEntity).CurrentValues.SetValues(entity);
                await db.SaveChangesAsync();

                return true;
            }
        }


        private IQueryable<T> Include(V db, params string[] includeProperties)
        {
            var query = db.Set<T>().AsQueryable();
            var navigations = db.Model.FindEntityType(typeof(T)).GetDerivedTypesInclusive().SelectMany(type => type.GetNavigations()).Distinct();
            foreach (var property in navigations)
            {
                if (includeProperties.Length > 0 && !includeProperties.Contains(property.Name)) continue;
                query = query.Include(property.Name);
            }
            return query;
        }
    }

    public class ServiceBaseNew<T, V> : IServiceBase<T> where T : EntityBase where V : ContextBase<T>
    {
        protected readonly V _context;
        public ServiceBaseNew(V context)
        {
            _context = context;
        }

        //public virtual async Task<bool> AddEntityAsync(T entity)
        //{
        //    var result = false;
        //    using (var db = (V)Activator.CreateInstance(typeof(V)))
        //    {
        //        db.Values.Add(entity);
        //        db.SaveChanges();
        //        result = true;
        //    }
        //    return result;
        //}

        public virtual async Task<int> AddEntityGetIdAsync(T entity)
        {
            var res = _context.Values.Add(entity);
            _context.SaveChanges();
            return res.Entity.id;
        }

        public virtual async Task<bool> DelEntityAsync(int id)
        {
            var findEntity = _context.Values.FirstOrDefault(x => x.id == id);
            if (findEntity == null) return false;

            _context.Values.Remove(findEntity);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> ExistsEntityAsync(int id)
        {
            return await _context.Values.AnyAsync(m => m.id == id);
        }

        public virtual async Task<List<T>> GetEntitiesAsync(params string[] includeProperties)
        {
            var query = Include(includeProperties);
            return query?.ToList();
        }

        public virtual async Task<T> GetEntityAsync(int id, params string[] includeProperties)
        {
            var query = Include( includeProperties);
            return query?.FirstOrDefault(x => x.id == id);
        }

        public virtual async Task<bool> UpdateEntityAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingEntity = await _context.Values.FindAsync(entity.id);
            if (existingEntity == null)
                return false;

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();

            return true;
        }


        private IQueryable<T> Include(params string[] includeProperties)
        {
            var query = _context.Set<T>().AsQueryable();
            var navigations = _context.Model.FindEntityType(typeof(T)).GetDerivedTypesInclusive().SelectMany(type => type.GetNavigations()).Distinct();
            foreach (var property in navigations)
            {
                if (includeProperties.Length > 0 && !includeProperties.Contains(property.Name)) continue;
                query = query.Include(property.Name);
            }
            return query;
        }
    }
}
