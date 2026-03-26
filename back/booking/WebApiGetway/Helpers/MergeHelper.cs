using System.Collections.Concurrent;
using System.Reflection;
using TranslationContracts;

namespace WebApiGetway.Helpers
{
    public class MergeHelper
    {
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> TypePropertiesCache = new();


        /// <summary>
        /// Универсальный merge: копирует совпадающие по имени и типу свойства
        /// из объектов <typeparamref name="TFrom"/> в объекты <typeparamref name="TSource"/>.
        /// Свойство Id игнорируется (регистронезависимо).
        /// Null значения пропускаются.
        /// </summary>
        public static void Merge<TSource, TFrom>(
            IEnumerable<TSource> source,
            IEnumerable<TFrom> from,
            Func<TSource, int> sourceKeySelector,
            Func<TFrom, int> fromKeySelector)
            where TSource : class
            where TFrom : class
        {
            if (source == null || from == null)
                return;

            // создаём словарь для быстрого поиска по ключу
            var dict = from
                .GroupBy(fromKeySelector)
                .ToDictionary(g => g.Key, g => g.First());

            // получаем свойства source (кешируем)
            var sourceProps = TypePropertiesCache.GetOrAdd(
                typeof(TSource),
                t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                      .Where(p => p.CanWrite && !string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase))
                      .ToArray()
            );

            // получаем свойства from (кешируем)
            var fromProps = TypePropertiesCache.GetOrAdd(
                typeof(TFrom),
                t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                      .ToArray()
            ).ToDictionary(p => p.Name, p => p);

            // перебираем все элементы source
            foreach (var item in source)
            {
                var key = sourceKeySelector(item);

                if (!dict.TryGetValue(key, out var fromItem))
                    continue;

                foreach (var prop in sourceProps)
                {
                    if (fromProps.TryGetValue(prop.Name, out var fromProp))
                    {
                        if (prop.PropertyType != fromProp.PropertyType)
                            continue;

                        var value = fromProp.GetValue(fromItem);
                        if (value == null)
                            continue;

                        prop.SetValue(item, value);
                    }
                }
            }
        }



        /// <summary>
        /// Копирует совпадающие по имени и типу свойства из объекта <typeparamref name="TFrom"/> 
        /// в объект <typeparamref name="TSource"/>. 
        /// Свойство Id игнорируется (регистронезависимо). 
        /// Null значения пропускаются.
        /// </summary>
        public static void MergeSingle<TSource, TFrom>(TSource source, TFrom from)
            where TSource : class
            where TFrom : class
        {
            if (source == null || from == null)
                return;

            // Получаем свойства source (кешируем)
            var sourceProps = TypePropertiesCache.GetOrAdd(
                typeof(TSource),
                t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                      .Where(p => p.CanWrite && !string.Equals(p.Name, "Id", StringComparison.OrdinalIgnoreCase))
                      .ToArray()
            );

            // Получаем свойства from (кешируем)
            var fromProps = TypePropertiesCache.GetOrAdd(
                typeof(TFrom),
                t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                      .ToArray()
            ).ToDictionary(p => p.Name, p => p);

            foreach (var prop in sourceProps)
            {
                if (fromProps.TryGetValue(prop.Name, out var fromProp))
                {
                    if (prop.PropertyType != fromProp.PropertyType)
                        continue;

                    var value = fromProp.GetValue(from);
                    if (value == null)
                        continue;

                    prop.SetValue(source, value);
                }
            }
        }

        /// <summary>
        /// Выполняет слияние данных, копируя совпадающие по имени и типу свойства 
        /// из объектов перевода (<see cref="TranslationResponse"/>) в целевые объекты.
        /// Свойство <c>id</c> не изменяется.
        /// </summary>
        /// <typeparam name="TSource">Тип целевой сущности.</typeparam>
        /// <param name="source">Коллекция целевых объектов, в которые применяется перевод.</param>
        /// <param name="translations">Коллекция объектов перевода.</param>
        /// <param name="sourceKeySelector">
        /// Функция для получения идентификатора целевого объекта (используется для сопоставления с <c>EntityId</c>).
        /// </param>
        /// 


        //public static void Merge<TSource>(
        //    IEnumerable<TSource> source,
        //    IEnumerable<TranslationResponse> translations,
        //    Func<TSource, int> sourceKeySelector)
        //    where TSource : class
        //{
        //    var dict = translations
        //        .GroupBy(t => t.EntityId)
        //        .ToDictionary(g => g.Key, g => g.First());

        //    var sourceProps = typeof(TSource).GetProperties()
        //        .Where(p => p.CanWrite && p.Name != "id")
        //        .ToList();

        //    var translationProps = typeof(TranslationResponse).GetProperties()
        //        .ToDictionary(p => p.Name, p => p);

        //    foreach (var item in source)
        //    {
        //        var key = sourceKeySelector(item);

        //        if (!dict.TryGetValue(key, out var translation))
        //            continue;

        //        foreach (var prop in sourceProps)
        //        {
        //            if (translationProps.TryGetValue(prop.Name, out var trProp))
        //            {
        //                if (prop.PropertyType != trProp.PropertyType)
        //                    continue;

        //                var value = trProp.GetValue(translation);
        //                prop.SetValue(item, value);
        //            }
        //        }
        //    }
        //}


        //===============================================================================================================
        /// <summary>
        /// Копирует все совпадающие свойства из объекта перевода (<see cref="TranslationResponse"/>)
        /// в целевой объект. Свойство <c>id</c> не изменяется.
        /// </summary>
        /// <typeparam name="TSource">Тип целевого объекта.</typeparam>
        /// <param name="objResult">Целевой объект, в который применяются переводы.</param>
        /// <param name="translation">Объект перевода.</param>
        public static void MergeSingle<TSource>(TSource objResult, TranslationResponse translation)
            where TSource : class
        {
            if (objResult == null || translation == null)
                return;

            var sourceProps = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanWrite && p.Name != "id")
                .ToList();

            var translationProps = typeof(TranslationResponse).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(p => p.Name, p => p);

            foreach (var prop in sourceProps)
            {
                if (translationProps.TryGetValue(prop.Name, out var trProp))
                {
                    if (prop.PropertyType != trProp.PropertyType)
                        continue;

                    var value = trProp.GetValue(translation);
                    prop.SetValue(objResult, value);
                }
            }
        }


    }
}
