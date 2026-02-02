using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Globals.Helpers
{
    public static class PatchHelper
    {
        /// <summary>
        /// Обновляет entity значениями из dto.
        /// Обновляются ТОЛЬКО:
        ///  - свойства, существующие в entity
        ///  - совместимые по типу
        ///  - не равные null
        /// </summary>
        public static void ApplyPatch<TEntity, TDto>(
            TEntity entity,
            TDto dto,
            params string[] excludedProperties
        )
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            var excluded = new HashSet<string>(
                excludedProperties ?? Array.Empty<string>(),
                StringComparer.OrdinalIgnoreCase
            );

            var dtoProperties = typeof(TDto)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var dtoProp in dtoProperties)
            {
                // исключённые поля (Id и т.п.)
                if (excluded.Contains(dtoProp.Name))
                    continue;

                var entityProp = typeof(TEntity).GetProperty(dtoProp.Name);

                if (entityProp == null)
                    continue;

                if (!entityProp.CanWrite)
                    continue;

                if (!entityProp.PropertyType.IsAssignableFrom(dtoProp.PropertyType))
                    continue;

                var value = dtoProp.GetValue(dto);

                if (value == null)
                    continue;

                entityProp.SetValue(entity, value);
            }
        }
    }
}
