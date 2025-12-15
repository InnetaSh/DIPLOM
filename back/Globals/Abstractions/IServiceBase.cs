using Globals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals.Abstractions
{
    public interface IServiceBase<T> where T : EntityBase
    {
        //Task<Boolean> AddEntityAsync(T entity);
        Task<int> AddEntityGetIdAsync(T entity);

        Task<T> GetEntityAsync(int id, params string[] includeProperties);

        Task<List<T>> GetEntitiesAsync(params string[] includeProperties);

        Task<Boolean> UpdateEntityAsync(T entity);

        Task<Boolean> DelEntityAsync(int id);

        Task<bool> ExistsEntityAsync(int id);
    }
}
